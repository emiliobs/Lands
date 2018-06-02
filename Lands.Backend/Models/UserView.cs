using Lands.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lands.Backend.Models
{
    //para  que no la tire a la bd:
    [NotMapped]
    public class UserView : User
    {
        //[Display (Name= "Picture")]   
        //public HttpPostedFileBase PictureFile { get; set; }   
        
        [DataType(DataType.Password)]    
        [Required(ErrorMessage = "The field {0} is required.")]    
        [StringLength(20, ErrorMessage = "The length for field {0} must be betwen {1} and {2} characteres", MinimumLength = 6)]
        public string Password { get; set; }                                                          
        
        [Display(Name = "Password Confirm")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(20, ErrorMessage = "The length for field {0} must be betwen {1} and {2} characteres", MinimumLength = 6)] 
        [Compare("Password", ErrorMessage = "The password and confirm does no match.")]                                         
        public string PasswordConfirm { get; set; }
    }
}