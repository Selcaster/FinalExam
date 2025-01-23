using FinalExam.BL.ViewModels.Doctor;

namespace FinalExam.BL.Services.DoctorService;

public interface IDoctorService
{
    Task<IEnumerable<DoctorGetVM>> GetAllAsync();
    Task<Guid> CreateAsync(DoctorCreateVM vm);
}
