namespace Lands.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Lands.Api.Models;
    using Lands.Api.UserHelper;
    using Lands.Domains;


    public class UsersController : ApiController
    {
        private LocalApiDatacontext db = new LocalApiDatacontext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(UserView view)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //aqui oregunto si el usuario tiene foto:
            if (view.ImageArray != null && view.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(view.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "~/Content/Images";
                var fullPath = $"{folder}/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    view.ImagePath = fullPath;
                }

                var user = ToUser(view);

                db.Users.Add(user);
            await db.SaveChangesAsync();
            UsersHelper.CreateUserASP(view.Email, "User", view.Password);

           
            }

            return CreatedAtRoute("DefaultApi", new { id = view.UserId }, view);
        }

        //tranformación de ojbjetos de userView A User:
        private User ToUser(UserView view)
        {
            return new User() {

                Email = view.Email,
                FirstName = view.FirstName,
                ImageArray = view.ImageArray,
                ImagePath = view.ImagePath,
                LastName = view.LastName,
                Password = view.Password,
                Telephone = view.Telephone,
                UserId = view.UserId,
                UserType = view.UserType,
                UserTypeId = view.UserTypeId,


            };
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}