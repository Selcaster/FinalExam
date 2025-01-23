using FinalExam.Core.Entities;
using FinalExam.Core.RepositoryInterfaces;
using FinalExam.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalExam.DAL.RepositoryImplements;


public class DepartmentRepository : GenericRepository<Departments>, IDepartmentRepository
{
    readonly AppDbContext _context;
    public DepartmentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
