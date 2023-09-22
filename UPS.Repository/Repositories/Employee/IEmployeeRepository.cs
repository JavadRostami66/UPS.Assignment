using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Repository.Common;

namespace UPS.Repository.Repositories.Employee
{
    public interface IEmployeeRepository : IGenericRepository<Domain.Domain.Employee, int>
    {
    }
}
