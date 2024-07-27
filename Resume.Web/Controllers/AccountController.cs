using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.Account;
using System.Security.Claims;

namespace Resume.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Fildes

        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        #region Methods

        [HttpGet("/LogIn")]
        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new {area   = "Admin" });
            }
            return View();
        }
        [HttpPost("/LogIn")]
        public async Task<IActionResult> LogIn(LoginViewModel model) 
        {
            var result = await _userService.LoginAsync(model);
           
            switch (result)
            {
                case LoginResult.Success:
                    var user = await _userService.GetByEmailAsync(model.Username.ToLower());

                    #region Login

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.MobilePhone, user.Phone)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = true, 
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData[SuccessMessage] = "خوش آمدید!";

                    #endregion

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید.";
                    return View(model);

                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری یافت نشد.";
                    return View(model);

                case LoginResult.PasswordError:
                    TempData[ErrorMessage] = "رمز اشتباه است .";
                    return View(model);
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }

        public IActionResult Register(LoginViewModel model)
        {
            return View();
        }

        #endregion
    }
}
