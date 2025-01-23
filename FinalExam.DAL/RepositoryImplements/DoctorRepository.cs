using FinalExam.Core.Entities;
using FinalExam.Core.RepositoryInterfaces;
using FinalExam.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalExam.DAL.RepositoryImplements;

public class DoctorRepository : GenericRepository<Doctors>, IDoctorRepository

{
    readonly AppDbContext _context;
    public DoctorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
