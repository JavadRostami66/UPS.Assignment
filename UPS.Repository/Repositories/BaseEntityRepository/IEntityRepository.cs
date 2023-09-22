using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;
using UPS.Repository.Common;

namespace UPS.Repository.Repositories.BaseEntityRepository
{
    public interface IEntityRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        TEntity GetById(TKey id);

        Task<TEntity> GetByIdAsync(TKey id);
    }
}
