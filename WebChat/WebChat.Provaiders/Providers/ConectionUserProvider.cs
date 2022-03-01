using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebChat.Domain;
using WebChat.Models;
using WebChat.Models.Models;

namespace WebChat.Provaiders.Providers
{
    class ConectionUserProvider : IServiceConectionUser
    {
        public void ConectionStatus(UserModels user)
        {
            using (var db = new dbContext())
            {
                var us = db.ConectionUsers.FirstOrDefault(x => x.UserName == user.Name && x.UserId == user.Id);
                if(us != null)
                {
                    us.Status = true;
                    db.SaveChanges();
                }
                else
                {
                    var newUserConect = new ConectionUser { UserName = user.Name, Date = DateTime.Now, Status = true ,UserId = user.Id};
                    db.ConectionUsers.Add(newUserConect);
                    db.SaveChanges();
                }
            }
        }
    }
}
