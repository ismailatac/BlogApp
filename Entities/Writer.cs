using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Message> Senders { get; set; }
        public List<Message> Receivers { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}