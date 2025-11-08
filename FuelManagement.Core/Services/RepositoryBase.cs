using FuelManagement.Core.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagement.Core.Services;

public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }
    public T Get(TKey id)
    {
        return _context.Find<T>(id);
    }

    // گرفت لیستی از آیتم ها
    public List<T> Get()
    {
        return _context.Set<T>().ToList();
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }
    public void CreateAsync(T entity)
    {
        _context.AddAsync(entity);
    }
    public bool Exists(Expression<Func<T, bool>> exception)
    {
        return _context.Set<T>().Any(exception);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    public void SaveChangesAsync()
    {
        _context.SaveChangesAsync();
    }
}
