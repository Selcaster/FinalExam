using FinalExam.BL.ViewModels.Doctor;

namespace FinalExam.BL.Services.DoctorService;

public interface IDoctorService
{
    Task<IEnumerable<DoctorGetVM>> GetAllAsync();
    Task<int> CreateAsync(DoctorCreateVM vm);
}
