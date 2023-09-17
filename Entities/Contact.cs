using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}