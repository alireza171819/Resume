using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.Resume
{
    public class AboutMeViewModel
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        ///  [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا فرمت نام کاربری معتبر وارد کنید")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the jobtitel
        /// </summary>
        ///  [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا فرمت نام کاربری معتبر وارد کنید")]
        public string JobTitel { get; set; }

        /// <summary>
        /// Gets or sets the jobtitel
        /// </summary>
        ///  [Display(Name = "ایمیل")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[EmailAddress(ErrorMessage = "لطفا فرمت نام کاربری معتبر وارد کنید")]
        //public string JobTitel { get; set; }
    }
}
