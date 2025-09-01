using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen  Adını Girin")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Lütfen Kullanıcı Görseli Girin")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Lütfem mail adresinizi giriniz.")]
        public string Mail { get; set; }
    }
}
