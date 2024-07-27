using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Account
{
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        ///  [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا فرمت ایمیل معتبر وارد کنید")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        ///   [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
    public enum LoginResult
    {
        Success,
        Error,
        UserNotFound,
        PasswordError
    }
}
