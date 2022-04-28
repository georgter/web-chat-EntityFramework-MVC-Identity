using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Web.Models
{
    public class LogChatViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogDate { get; set; }
    }
}