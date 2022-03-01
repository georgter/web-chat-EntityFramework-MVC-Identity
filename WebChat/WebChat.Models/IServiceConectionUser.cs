using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Models.Models;

namespace WebChat.Models
{
    public interface IServiceConectionUser
    {
        void ConectionStatusOnline(UserModels user);
        void ConectionStatusOffline(UserModels user);
       
    }
}
