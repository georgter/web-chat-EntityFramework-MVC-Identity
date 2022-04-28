using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.DAL.Entities
{
    public class LogChat
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogDate { get; set; }
    }
}
