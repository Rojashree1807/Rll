using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLibrary.Domain_Classes
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required(ErrorMessage = "Please enter message")]
        public string Message_ { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int SenderId { get; set; }
        public object MessageTime { get; internal set; }
    }
}
