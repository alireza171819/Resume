using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.ViewModels.User;

public class UpdateUserViewModel
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the username
    /// </summary>
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 250 باشد .")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the gender
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(10, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 10 باشد .")]
    public string Gender { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MaxLength(11, ErrorMessage = "تعداد کاراکتر ها باید کمتر از 11 باشد .")]
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the date of birth
    /// </summary>
    [Display(Name = "")]
    [Required(ErrorMessage = "")]
    [MaxLength(250, ErrorMessage = "")]
    public DateTime? DateOfBirth { get; set; }
}

public enum UpdateUserResult
{
    Success,
    Error ,
    UserNotFound,
    EmailDuplicated,
    PhoneDuplicated
}
