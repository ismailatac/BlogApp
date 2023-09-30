using Entities;

namespace BlogApp.Models
{
    public class NewsletterModel
    {
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
        public int BlogId { get; set; }
    }
}