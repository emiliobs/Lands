using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lands.Domain
{
   public  class prueba
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
