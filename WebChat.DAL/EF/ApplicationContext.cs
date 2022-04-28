using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;

namespace WebChat.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser> 
    {
        public ApplicationContext() :base("AccountController")
        {
        }

        //public ApplicationContext(string connectionString) : base() { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<LogChat> LogChats { get; set; }
    }

}
