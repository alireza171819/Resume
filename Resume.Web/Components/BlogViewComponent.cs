using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Extensions;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Components;

public partial class BlogViewComponent : ViewComponent
{
    #region Fileds

    private readonly IUserService _userService;

    #endregion


    #region Ctor
    public BlogViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }

    #endregion
}
