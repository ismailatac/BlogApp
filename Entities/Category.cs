using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}