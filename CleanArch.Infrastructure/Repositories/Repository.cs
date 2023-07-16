using CleanArch.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetSingleAsync(object id)
        {
            var entities = _context.Set<T>() ?? throw new Exception("Entity not found");
            return await entities.FindAsync(id) ?? throw new Exception("Entity not found");
        }
        public async Task<List<T>> GetAllAsync()
        {
            var entities = _context.Set<T>() ?? throw new Exception("Entity not found");
            return await entities.ToListAsync();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var entities = _context.Set<T>() ?? throw new Exception("Entity not found");
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var entities = _context.Set<T>() ?? throw new Exception("Entity not found");
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            var entities = _context.Set<T>() ?? throw new Exception("Entity not found");
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
