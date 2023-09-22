using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;
using UPS.Domain;
using Microsoft.EntityFrameworkCore;

namespace UPS.Repository.Common
{
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : Entity<TKey>
    {
        private readonly EmployeeContext _context;
        private readonly IUnitOfWork _unitOfWork;

        internal DbSet<T> dbSet;


        protected GenericRepository(EmployeeContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
            //var entityType = _context.Model.FindEntityType(typeof(T));
        }

        public IQueryable<T> Query()
        {
            return dbSet.AsQueryable();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return dbSet.ToList();
        }

        public async Task<T> FindAsync(Func<T, bool> match)
        {
            return dbSet.SingleOrDefault(match);
        }

        public async Task<List<T>> FindAllAsync(Func<T, bool> match)
        {
            return dbSet.Where(match).ToList();
        }

        public T Add(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }
        public T Update(T updated)
        {
            dbSet.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            return updated;
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);

        }
        public int Count()
        {
            return dbSet.Count();
        }

        public bool Any()
        {
            return dbSet.Any();
        }
        public bool Any(Expression<Func<T, bool>> match)
        {
            return dbSet.Any(match);
        }

        public int Count(Expression<Func<T, bool>> match)
        {
            return dbSet.Count(match);
        }

        public T FirstOrDefault()
        {
            return dbSet.FirstOrDefault();
        }
        public async Task<T> FirstOrDefaultAsync()
        {
            return await dbSet.FirstOrDefaultAsync();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> match)
        {
            return dbSet.FirstOrDefault(match);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match)
        {
            return await dbSet.FirstOrDefaultAsync(match);
        }

        public T SingleOrDefault()
        {
            return dbSet.SingleOrDefault();
        }
        public async Task<T> SingleOrDefaultAsync()
        {
            return await dbSet.SingleOrDefaultAsync();
        }
        public T SingleOrDefault(Expression<Func<T, bool>> match)
        {
            return dbSet.SingleOrDefault(match);
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> match)
        {
            return await dbSet.SingleOrDefaultAsync(match);
        }



        public async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = dbSet.Where(predicate);
            return exist.Any() ? true : false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
