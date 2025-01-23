using FinalExam.BL.ViewModels.Department;

namespace FinalExam.BL.Services.DepartmentService;

public interface IDepartmentService
{
    Task<Guid> CreateAsync(DepartmentCreateVM vm);
    Task<IEnumerable<DepartmentGetVM>> GetAllAsync();
}