using System;
using System.Collections.Generic;
using System.Text;

namespace WebChat.Domain.Models
{
    class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
    }
}
