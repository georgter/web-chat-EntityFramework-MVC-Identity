using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.EF;
using WebChat.DAL.Entities;

namespace WebChat.DAL.Repositories
{
    public class Serch
    {
        public ApplicationContext Database { get; set; }
        public Serch()
        {
            //Database = new ApplicationContext("AccountController");
            Database = new ApplicationContext();
        }
        /// <summary>
        /// Получения всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<ClientProfile> GetAllUsers()
        {
            var users = new List<ClientProfile>();
            users = Database.ClientProfiles.ToList();
            return users;
        }

        public string GetUserId(string name)
        {
              var user =  Database.ClientProfiles.FirstOrDefault(x => x.Name == name);
            return user.Id;
        }

        public string GetUserName(string id)
        {
            var user = Database.ClientProfiles.FirstOrDefault(x => x.Id == id);
            return user.Name;
        }
    }
}
