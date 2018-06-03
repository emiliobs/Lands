namespace Lands.Backend.Models
{
    using Lands.Domains;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;

    public class LocalDatacontext : DataContext
    {
        public System.Data.Entity.DbSet<Lands.Domains.User> Users { get; set; }

        public System.Data.Entity.DbSet<Lands.Domains.UserType> UserTypes { get; set; }
    }
}