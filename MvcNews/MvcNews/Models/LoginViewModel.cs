using System.ComponentModel.DataAnnotations;

namespace MvcNews.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        
        [Display(Name = "Parola")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Beni Hatırla")]
        public bool IsPersistent { get; set; }

        public string ReturnUrl { get; set; }

    }
}