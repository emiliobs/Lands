namespace Lands.Models
{
    public class User
    {
      
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

      
        public string Email { get; set; }

      
        public string Telephone { get; set; }

    
        public string ImagePath { get; set; }

        //Relations
        public int UserTypeId { get; set; }

       
        public virtual UserType UserType { get; set; }

       
        public byte[] ImageArray { get; set; }

       
        public string Password { get; set; }


        public string ImageFullPath => string.IsNullOrEmpty(this.ImagePath) ? "NoImage" : $"http://landsapi5.azurewebsites.net/{ImagePath.Substring(1)}";

       
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
