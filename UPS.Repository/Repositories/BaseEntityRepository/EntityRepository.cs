using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain;
using UPS.Domain.Common;
using UPS.Repository.Common;

namespace UPS.Repository.Repositories.BaseEntityRepository
{
    public class EntityRepository<TEntity, TKey> : GenericRepository<TEntity, TKey>, IEntityRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly EmployeeContext _context;
        public EntityRepository(EmployeeContext context) : base(context)
        {
            _context = context;
        }

        public TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
