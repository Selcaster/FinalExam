using AutoMapper;
using FinalExam.BL.Services.DepartmentService;
using FinalExam.BL.Services.DoctorService;
using FinalExam.BL.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.MVC.Controllers;

public class HomeController(IDepartmentService _departmentService, IDoctorService _doctorService, IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(new HomeVM
        {
            DepartmentGetVM = await _departmentService.GetAllAsync(),
            DoctorGetVM = await _doctorService.GetAllAsync(),
        });
    }
}