using AutoMapper;
using FinalExam.BL.ViewModels.Doctor;
using FinalExam.Core.Entities;
using FinalExam.Core.RepositoryInterfaces;

namespace FinalExam.BL.Services.DoctorService;

public class DoctorService(IDoctorRepository _repository, IMapper _mapper) : IDoctorService
{
    public async Task<int> CreateAsync(DoctorCreateVM vm)
    {
        Doctors doctor = _mapper.Map<Doctors>(vm);
        await _repository.CreateAsync(doctor);
        _repository.SaveChanges();
        return doctor.Id;
    }

    public async Task<IEnumerable<DoctorGetVM>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<DoctorGetVM>>(_repository.GetAll());
    }
}
