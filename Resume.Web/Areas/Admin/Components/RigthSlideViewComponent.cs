using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Extensions;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels;
using Resume.DAL.ViewModels.User;

namespace Resume.Web.Areas.Admin.Components;

public partial class RigthSlideViewComponent : ViewComponent
{
    #region Fileds

    private readonly IUserService _userService;

    #endregion


    #region Ctor
    public RigthSlideViewComponent(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        InfoUserViewModel user = await _userService.GetInfoAsync(User.GetUserId());
        return View(user);
    }

    #endregion
}
