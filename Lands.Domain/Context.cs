using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Lands.Domain
{
    public class Context: DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }
    }
}
