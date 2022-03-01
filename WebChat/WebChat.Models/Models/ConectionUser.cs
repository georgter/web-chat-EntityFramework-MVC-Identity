using System;
using System.Collections.Generic;
using System.Text;

namespace WebChat.Models.Models
{
    public class ConectionUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public UserModels UserModels { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        //public IEnumerable<UserModels> Users { get; set; }
    }
}
