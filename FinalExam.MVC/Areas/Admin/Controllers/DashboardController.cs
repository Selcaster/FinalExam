using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinalExam.Core.Entities;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Roles = FinalExam.Core.Entities.Roles;

namespace FinalExam.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(Roles.Admin))]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
