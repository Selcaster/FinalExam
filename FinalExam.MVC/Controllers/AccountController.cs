using FinalExam.BL.ViewModels.Doctor;
using FinalExam.BL.ViewModels.Department;
using FinalExam.BL.Services.DepartmentService;
using FinalExam.BL.Services.DoctorService;
using Microsoft.AspNetCore.Mvc;
using FinalExam.BL.Services.AuthServices;
using FinalExam.BL.Services;
namespace FinalExam.MVC.Controllers;

public class AccountController : Controller
    {
        readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                await _authService.Login(userDTO);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                await _authService.Register(registerDTO);
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.Logout();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
