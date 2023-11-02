using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class UserSignUpModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }
        
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Lütfen şifre giriniz")]
        public string Password { get; set; }

        [Display(Name ="Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen mail adresi giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
    }
}
