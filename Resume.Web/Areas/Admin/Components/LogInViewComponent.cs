using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Components;

public partial class LogInViewComponent : ViewComponent
{
    public LogInViewComponent()
    {
        
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("LogIn");
    }
}
