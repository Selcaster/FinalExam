using AutoMapper;
using FinalExam.BL.ViewModels.Doctor;
using FinalExam.Core.Entities;

namespace FinalExam.BL.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<DoctorCreateVM, Doctors>().ReverseMap();
        CreateMap<DoctorGetVM, Doctors>().ReverseMap();
        CreateMap<DoctorUpdateVM, Doctors>().ReverseMap();
    }
}
