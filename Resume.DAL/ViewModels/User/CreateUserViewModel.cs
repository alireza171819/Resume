using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.User;

public class InsertUserViewModel
{
    /// <summary>
    /// Gets or sets the username
    /// </summary>
    [Display(Name ="نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    [Display(Name ="ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the gender
    /// </summary>
    [Display(Name = "جنسیت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    [Display(Name = "موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(11, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 11 باشد .")]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(18, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 18 باشد .")]
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the date of birth
    /// </summary>
    [Display(Name = "تاریخ تولد")]
    [Required(ErrorMessage = "")]
    [MaxLength(250, ErrorMessage = "")]
    public DateTime? DateOfBirth { get; set; }
}

public enum InsertUserResult
{
    Success,
    Error
}
