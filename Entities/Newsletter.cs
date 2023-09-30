using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
