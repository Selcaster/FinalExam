using FinalExam.BL.ViewModels.Department;

namespace FinalExam.BL.Services.DepartmentService;

public interface IDepartmentService
{
    Task<int> CreateAsync(DepartmentCreateVM vm);
    Task<IEnumerable<DepartmentGetVM>> GetAllAsync();
}