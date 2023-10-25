using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
