using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;

namespace UPS.Repository.Common
{
    public interface IGenericRepository<T, TKey> where T : Entity<TKey>
    {
        IQueryable<T> Query();

        List<T> GetAll();

        Task<IList<T>> GetAllAsync();

        Task<T> FindAsync(Func<T, bool> match);

        Task<List<T>> FindAllAsync(Func<T, bool> match);

        T Add(T entity);
        T Update(T updated);
        void Delete(T entity);

        int Count();
        int Count(Expression<Func<T, bool>> match);

        bool Any();
        bool Any(Expression<Func<T, bool>> match);

        T FirstOrDefault();
        T FirstOrDefault(Expression<Func<T, bool>> match);
        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> match);


        T SingleOrDefault();
        T SingleOrDefault(Expression<Func<T, bool>> match);
        Task<T> SingleOrDefaultAsync();
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> match);



        Task<int> CountAsync();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        bool Exist(Expression<Func<T, bool>> predicate);
        void Dispose();

    }
}
