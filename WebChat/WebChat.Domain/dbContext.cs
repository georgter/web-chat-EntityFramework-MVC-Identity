using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using WebChat.Models.Models;

namespace WebChat.Domain
{
    public class dbContext :DbContext
    {
        public dbContext() : base("DbConnection") { }

        public DbSet<UserModels> Users { get; set; }

        public DbSet<ConectionUser> ConectionUsers { get; set; }
    }
}
