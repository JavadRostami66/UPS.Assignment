using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain;
using UPS.Repository.Common;

namespace UPS.Repository.Repositories.Employee
{
    public class EmployeeRepository : GenericRepository<Domain.Domain.Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            if (!context.Employees.Any())
            {
                context.LoadEmployees();
            }
        }

        public new Domain.Domain.Employee Add(Domain.Domain.Employee entity)
        {
            entity.Id = 1;
            if (dbSet.Any())
            {
                var maxId = dbSet.Max(row => row.Id);
                entity.Id = maxId + 1;
            }
            return base.Add(entity);
        }
    }
}
