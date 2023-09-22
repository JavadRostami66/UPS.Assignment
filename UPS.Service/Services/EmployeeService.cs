using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Repository.Common;
using UPS.Repository.Repositories.Employee;
using UPS.Service.Common;
using UPS.Service.Result;
using UPS.Service.ViewModel.Employee;

namespace UPS.Service.Services
{
    public class EmployeeService : GenericService<Domain.Domain.Employee, int>,
    IEmployeeService
    {
        private IEmployeeRepository _EmployeeRepository;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork,
            IEmployeeRepository repository) : base(
            unitOfWork,
            repository)
        {
            _unitOfWork = unitOfWork;
            _EmployeeRepository = repository;
        }
        public Task<List<Domain.Domain.Employee>> GetByEmployeeId(int employeetId)
        {
            return _EmployeeRepository.FindAllAsync(r => r.Id.Equals(employeetId));
        }

        public Task<IList<Domain.Domain.Employee>> GetAllEmployee()
        {
            return _EmployeeRepository.GetAllAsync();
        }

        public Task<List<Domain.Domain.Employee>> SearchEmployeeByName(string employeetName)
        {
            return _EmployeeRepository.FindAllAsync(r => r.Name.StartsWith(employeetName));
        }

        public Task<MessageResult<Domain.Domain.Employee>> UpdateEmployee(Domain.Domain.Employee employee)
        {
            return base.UpdateAsync(employee);
        }

        public Task<Domain.Domain.Employee> GetByEmployeeName(string employeetName)
        {
            return _EmployeeRepository.FindAsync(r => r.Name.Equals(employeetName));
        }
        public Task<MessageResult<int>> DeleteEmployee(Domain.Domain.Employee employee)
        {
            return base.DeleteAsync(employee);
        }
        
    }
}
