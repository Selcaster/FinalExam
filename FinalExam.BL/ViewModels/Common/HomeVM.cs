using FinalExam.BL.ViewModels.Department;
using FinalExam.BL.ViewModels.Doctor;

namespace FinalExam.BL.ViewModels.Common;

public class HomeVM
{
    public IEnumerable<DepartmentGetVM> DepartmentGetVM { get; set; }
    public IEnumerable<DoctorGetVM> DoctorGetVM { get; set; }
}