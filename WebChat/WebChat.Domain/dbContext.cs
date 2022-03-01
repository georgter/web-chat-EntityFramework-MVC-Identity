using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using WebChat.Domain.Models;
namespace WebChat.Domain
{
    public class dbContext :DbContext
    {
        public dbContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
    }
}
