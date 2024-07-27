using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class AdminBaseController : Controller
    {

        protected string SuccessMessage = "Success Message ";

        protected string ErrorMessage = "Error Message ";
    }
}
