using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Models.Models;

namespace WebChat.Models
{
    public interface IServiceUser
    {
        void Registration(UserModels user);
        
    }
}
