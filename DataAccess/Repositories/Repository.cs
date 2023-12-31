﻿using Microsoft.EntityFrameworkCore;
using TrabajoFinalSofttek.DataAccess.Repositories.Interfaces;

namespace TrabajoFinalSofttek.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Agregar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }


        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

    }
}
