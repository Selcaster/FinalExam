using FinalExam.BL.Services.AuthServices;
using FinalExam.BL.Services.DepartmentService;
using FinalExam.BL.Services.DoctorService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BL.Services;


   public class AuthService : IAuthService
{
    readonly UserManager _userManager;
    readonly SignInManager _signInManager;

    public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task Login(Services.AuthServices.LoginDTO loginDTO)
    {
        IdentityUser? userDB = await _userManager.FindByEmailAsync(loginDTO.Email);
        if (userDB is null)
        {
            throw new Exception("Credentials are not correct.");
        }
        bool isAllowed = await _userManager.CheckPasswordAsync(userDB, loginDTO.Password);
        if (!isAllowed)
        {
            throw new Exception("Credentials are not correct.");
        }
        await _signInManager.SignInAsync(userDB, true);
    }


    public async Task Register(Services.AuthServices.RegisterDTO registerDTO)
    {
        IdentityUser user = new IdentityUser()
        {
            Email = registerDTO.Email,
            UserName = registerDTO.UserName,
        };
        IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }
    }
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}

