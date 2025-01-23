using AutoMapper;
using FinalExam.BL.ViewModels.Department;
using FinalExam.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalExam.BL.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Departments, DepartmentCreateVM>().ReverseMap();
        CreateMap<Departments, DepartmentGetVM>().ReverseMap();
        CreateMap<Departments, DepartmentUpdateVM>().ReverseMap();
    }
}