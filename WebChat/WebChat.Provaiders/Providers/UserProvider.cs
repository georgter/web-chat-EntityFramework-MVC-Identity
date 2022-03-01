using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Domain;
using WebChat.Models;
using WebChat.Models.Models;
using WebChat.Provaiders.Models;

namespace WebChat.Provaiders.Providers
{
    class UserProvider : IServiceUser
    {

        public void Registration(UserModels user)
        {
            using (var db = new dbContext())
            {
                var newUser = new User {Name = user.Name, Login = user.Login, Pass = user.Pass};
                db.Users.Add(newUser);
                db.SaveChanges();

            }
        }
    }
}