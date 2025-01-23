using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FinalExam.BL.ViewModels.Auths;

namespace FinalExam.MVC.Areas.Admin.ViewComponents;

public class AdminHeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        UserAdminInfoVM vm = new();
        vm.IsAuth = HttpContext.User?.Identity?.IsAuthenticated ?? false;
        vm.Username = HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value ?? "unknown"; // Fullname is custom given property outside AspNet.Identity
        return View(vm);
    }
}
