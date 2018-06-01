namespace Lands.Backend.Helpers
{
    using System;

    using System.Threading.Tasks;

    using Domains;

    using Models;

    public class DBHelper
    {
        public async static Task<Response2> SaveChanges(LocalDatacontext db)
        {

            try
            {

                await db.SaveChangesAsync();

                return new Response2 { IsSuccess = true, };

            }
            catch (Exception ex)
            {

                var response = new Response2 { IsSuccess = false, };

                if (ex.InnerException != null &&

                    ex.InnerException.InnerException != null &&

                    ex.InnerException.InnerException.Message.Contains("_Index"))

                {

                    response.Message = "There is a record with the same value";

                }

                else if (ex.InnerException != null &&

                         ex.InnerException.InnerException != null &&

                         ex.InnerException.InnerException.Message.Contains("REFERENCE"))

                {

                    response.Message = "The record can't be delete because it has related records";

                }

                else
                {

                    response.Message = ex.Message;

                }
                return response;

            }

        }

    }
}