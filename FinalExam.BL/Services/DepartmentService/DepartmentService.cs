using AutoMapper;
using FinalExam.BL.ViewModels.Department;
using FinalExam.Core.Entities;
using FinalExam.Core.RepositoryInterfaces;

namespace FinalExam.BL.Services.DepartmentService;

public class DepartmentService(IDepartmentRepository _repository, IMapper _mapper) : IDepartmentService
{
    public async Task<Guid> CreateAsync(DepartmentCreateVM vm)
    {
        Departments department = _mapper.Map<Departments>(vm);
        await _repository.CreateAsync(department);
        _repository.SaveChanges();
        return department.Id;
    }

    public async Task<IEnumerable<DepartmentGetVM>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<DepartmentGetVM>>(_repository.GetAll());
    }
}
