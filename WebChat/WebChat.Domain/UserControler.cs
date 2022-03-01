using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Models.Models;

namespace WebChat.Domain
{
    public class UserControler
    {
        public void UserAdd(UserModels user)
        {
            using (var db = new dbContext())
            {
                var newUser = new UserModels { Name = user.Name, Login = user.Login, Pass = user.Pass };
                db.Users.Add(newUser);
                db.SaveChanges();

            }
        }

    }
}
