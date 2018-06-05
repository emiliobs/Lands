using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lands.Domains
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The field {0}  is requered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum of {1} characteres lenght")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The field {0}  is requered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum of {1} characteres lenght")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0}  is requered.")]
        [MaxLength(100, ErrorMessage = "The field {0} only can contain a maximum of {1} characteres lenght")]
        [Index("User_Email_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} only can contain a maximum of {1} characteres lenght")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        //Relations
        public int UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(this.ImagePath) ? "NoImage" : $"http://landsapi5.azurewebsites.net/{ImagePath.Substring(1)}";

        [Display(Name = "User")]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
