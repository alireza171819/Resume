using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Resume.Bussines.Services.Interface;
using Resume.DAL.ViewModels.User;
using System.Net;
using System.Text.Encodings.Web;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {

        #region Fields 

        private readonly IUserService _userService;

        #endregion

        #region Ctor 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Methods
        public virtual async Task<IActionResult> Info() 
        {
            return View(); 
        }
        
        public virtual async Task<IActionResult> List(FilterUserViewModel model)
        {
            var user = await _userService.SearchAsync(model);
            return View(user);
        }

        public virtual async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public virtual async Task<IActionResult> Create(InsertUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userService.InsertAsync(model);

            switch (result)
            {
                case InsertUserResult.Success:
                    break;
                case InsertUserResult.Error:
                    break;
            }
            return View();
        }

        public virtual async Task<IActionResult> Update(int Id)
        {
            var user = await _userService.GetForEditByIdAsync(Id);
         
            return View();
        }
        [HttpPost]
        public virtual async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.UpdateAsync(model);

            switch (result)
            {
                case UpdateUserResult.Success:
                    break;
                case UpdateUserResult.Error:
                    break;
                case UpdateUserResult.UserNotFound:
                    break;
                case UpdateUserResult.PhoneDuplicated:
                    break;
                case UpdateUserResult.EmailDuplicated:
                    break;
            }
            return View();
        }


        #endregion
    }
}
