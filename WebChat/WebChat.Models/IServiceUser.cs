using System;
using System.Collections.Generic;
using System.Text;
using WebChat.Models.Models;

namespace WebChat.Models
{
    public interface IServiceUser
    {
        void Registration(UserModels user);

        bool isThere(string name);

        UserModels Authorization(string Login, string Pass);
    }
}
