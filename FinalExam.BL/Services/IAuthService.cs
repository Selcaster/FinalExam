using FinalExam.BL.Services.AuthServices;
using FinalExam.BL.Services.DoctorService;
using FinalExam.BL.Services.DepartmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.BL.Services;

public interface IAuthService
{
    public Task Login(Services.AuthServices.LoginDTO loginDTO);
    public Task Register(Services.AuthServices.RegisterDTO registerDTO);
    public Task Logout();
}
