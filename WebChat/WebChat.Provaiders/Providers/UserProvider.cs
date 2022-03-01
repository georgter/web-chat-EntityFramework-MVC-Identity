using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Domain;
using WebChat.Models;
using WebChat.Models.Models;

namespace WebChat.Provaiders.Providers
{
    public class UserProvider : IServiceUser
    {

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
                    db.SaveChanges();

                }
            }
        }
    }
}