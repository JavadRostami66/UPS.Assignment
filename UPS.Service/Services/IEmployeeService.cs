using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Service.Common;
using UPS.Service.Result;

namespace UPS.Service.Services
{
    public interface IEmployeeService : IGenericService<Domain.Domain.Employee, int>
    {
        Task<List<Domain.Domain.Employee>> GetByEmployeeId(int productId);
        Task<IList<Domain.Domain.Employee>> GetAllEmployee();
        Task<List<Domain.Domain.Employee>> SearchEmployeeByName(string employeetName);
        Task<MessageResult<Domain.Domain.Employee>> UpdateEmployee(Domain.Domain.Employee employee);
        Task<Domain.Domain.Employee> GetByEmployeeName(string employeetName);

        Task<MessageResult<int>> DeleteEmployee(Domain.Domain.Employee employee);
    }
}
