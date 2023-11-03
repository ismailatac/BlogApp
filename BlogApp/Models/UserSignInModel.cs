using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class UserSignInModel
    {
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
    }
}
