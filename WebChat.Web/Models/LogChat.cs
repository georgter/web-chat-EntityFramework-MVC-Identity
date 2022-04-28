using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Web.Models
{
    public class LogChat
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        public string LogMessage { get; set; }
        public string LogDate { get; set; }
    }
}