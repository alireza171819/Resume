using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.DAL.ViewModels.User;

public class FilterUserViewModel : BasePaging<InfoUserViewModel>
{
    [Display(Name = "نام کاربری")]
    public string? Username { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }

    [Display(Name = "جنسیت")]
    public string? Gender { get; set; }

    [Display(Name = "تلفن")]
    public string? Phone { get; set; }

    [Display(Name = "تاریخ تولد")]
    public DateTime? DateOfBirth { get; set; }
}
