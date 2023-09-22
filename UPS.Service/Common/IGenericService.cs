using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;
using UPS.Service.Result;

namespace UPS.Service.Common
{
    public interface IGenericService<T, TKey> : IService where T : Entity<TKey>
    {
        Task<T> GetById(TKey recNo);
        Task<IList<T>> GetAllAsync();
        ListResult<T> GetAll();
        Task<MessageResult<int>> DeleteAsync(T entity);
        Task<MessageResult<T>> AddAsync(T entity);
        MessageResult<T> Add(T entity);
        MessageResult<T> Update(T entity);
        Task<MessageResult<T>> UpdateAsync(T entity);
        MessageResult<T> FirstOrDefault();
    }
}
