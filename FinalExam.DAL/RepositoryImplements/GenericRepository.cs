using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FinalExam.Core.Entities;
using FinalExam.Core.RepositoryInterfaces;
using FinalExam.DAL.Context;

namespace FinalExam.DAL.RepositoryImplements;

public class GenericRepository<T>(AppDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
{
    protected DbSet<T> Table = _context.Set<T>();
    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
        SaveChanges();
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
        SaveChanges();
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        Delete(await GetByIdAsync(id));
        SaveChanges();
    }

    public IQueryable<T> FindAll(Expression<Func<T, bool>> filter)
        => Table.Where(filter).AsQueryable();

    public IQueryable<T> GetAll()
        => Table.AsQueryable();

    public async Task<T?> GetByIdAsync(Guid id)
        => await Table.FindAsync(id);

    public async Task<bool> IsExist(Guid id)
        => await Table.AnyAsync(x => x.Id == id);


    public Task<T> UpdateAsync(T entity)
    {
        //TODO: Update
        return null;
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}