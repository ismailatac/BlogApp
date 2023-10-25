using Microsoft.AspNetCore.Http;

namespace BlogApp.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; } //Java'daki karşılığı MultipartFile
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
