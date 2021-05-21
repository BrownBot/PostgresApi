using Microsoft.EntityFrameworkCore;
using PostgresApi.DataAccess.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresApi.DataAccess
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext context)
        {
            _context = context;
        }

        private DbContext _context;
        public DbContext Context => _context;

        public IQueryable<T> Query()
        {
            return Query<T>();
        }
        public IQueryable<U> Query<U>() where U : class
        {
            return _context.Set<U>();
        }

        public void Add(T entity)
        {
            Add<T>(entity);
        }
        public void Add<U>(U entity) where U : class
        {
            var set = _context.Set<U>();
            set.Add(entity);
        }


        public void Remove(T entity)
        {
            Remove<T>(entity);
        }
        public void Remove<U>(U entity) where U : class
        {
            var set = _context.Set<U>();
            set.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
            
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }
        public void Update<U>(U entity) where U : class
        {
            var set = _context.Set<U>();
            set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }
}
