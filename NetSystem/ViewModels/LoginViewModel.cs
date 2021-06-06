using System.ComponentModel.DataAnnotations;

namespace NetSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0}  الزامی است")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0}  الزامی است")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
