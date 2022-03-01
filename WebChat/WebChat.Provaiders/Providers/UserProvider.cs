using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebChat.Domain;
using WebChat.Models;
using WebChat.Models.Models;

namespace WebChat.Provaiders.Providers
{
    public class UserProvider : IServiceUser
    {
        ConectionUserProvider cup = new ConectionUserProvider();
        public UserModels Authorization(string Login, string Pass)
        {

            using (var db = new dbContext())
            {
                var us = db.Users.FirstOrDefault(x => x.Login == Login && x.Pass == Pass);
                if (us != null)
                {
                    cup.ConectionStatus(us);
                    return us;
                }
                return null;
            }
        }
        /// <summary>
        /// Проверка есть ли такой пользователь 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isThere(string name)
        {
            using (var db = new dbContext())
            {
                var there = db.Users.FirstOrDefault(x => x.Login == name);
                return there== null? false : true;
            }
        }

        public void Registration(UserModels user)
        {
          
                if((user.Name!= null && user.Name.Trim() == "")
                    || (user.Pass!= null && user.Pass.Trim()=="")
                    ||(user.Login != null && user.Login.Trim() == "")  
                    || user.Name == null || user.Pass == null || user.Login == null)
                {
                throw new Exception("Не коректные даные");
                }
                else
                {
                using (var db = new dbContext())
                {
                    var newUser = new UserModels { Name = user.Name, Login = user.Login, Pass = user.Pass };
                    db.Users.Add(newUser);

                    cup.ConectionStatus(newUser);

                    db.SaveChanges();
                }
            }
        }
    }
}