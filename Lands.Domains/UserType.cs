namespace Lands.Domains
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "The field {0}  is requered.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum of {1} characteres lenght")]
        [Index("UserType_Name_Index", IsUnique = true)]
       public string Name { get; set; }
    }

}
