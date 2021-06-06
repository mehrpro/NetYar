using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace NetSystem.ViewModels
{
    /// <summary>
    /// ثبت نام
    /// </summary>
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0}  الزامی است")]
        [Display(Name = "نام کاربری")]
        [Remote("IsUserNameAvailable", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }

        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "{0}  الزامی است")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?i)(?=.*[a-z])(?=.*[0-9])(?=.*[@#_])[a-z][a-z0-9@#_]{8,}[a-z0-9]$", ErrorMessage = "رمزعبور باید شامل حروف انگلیسی بزرگ وکوچک و اعداد و یک کاراکتر ویژه و 8 الی 15 کاراکتر باشد")]

        public string Password { get; set; }

        [Display(Name = "تکرار رمزعبور")]
        [Required(ErrorMessage = "{0}  الزامی است")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "رمزعبور و تکرار آن مطابقت ندارند")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0}  الزامی است")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "قالب بندی ایمیل رعایت نشده است")]
        [Remote("IsEmailAvailable", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken")]
        public string Email { get; set; }


    }
}
