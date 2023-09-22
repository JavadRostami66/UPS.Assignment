using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UPS.API.ActionFilters;
using UPS.Service.Services;
using UPS.Service.ViewModel.Employee;

namespace UPS.API.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IList<UPS.Domain.Domain.Employee> Employees = await _employeeService.GetAllEmployee();
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                foreach (var item in Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel
                    {
                        Name = item.Name,
                        Dept = item.Dept,
                        Address = item.Address
                    });
                }
                return Ok(employeeViewModels);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> Get(int employeeId)
        {
            try
            {
                IList<UPS.Domain.Domain.Employee> Employees = await _employeeService.GetByEmployeeId(employeeId);
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                foreach (var item in Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel
                    {
                        Name = item.Name,
                        Dept = item.Dept,
                        Address = item.Address
                    });
                }
                return Ok(employeeViewModels);
            }
            catch (Exception e)
            {
                throw e;
            }

        }





        [HttpGet("SearchEmployeeByName")]
        public async Task<IActionResult> SearchEmployeeByName(string employeeName)
        {
            try
            {
                IList<UPS.Domain.Domain.Employee> Employees = await _employeeService.SearchEmployeeByName(employeeName);
                List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
                foreach (var item in Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel
                    {
                        Name = item.Name,
                        Dept = item.Dept,
                        Address = item.Address
                    });
                }
                return Ok(employeeViewModels);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> Update(EmployeeViewModel employee)
        {
            try
            {
                UPS.Domain.Domain.Employee employeeEntity = await _employeeService.GetByEmployeeName(employee.Name);
                if (employeeEntity != null)
                {
                    employeeEntity.Dept = employee.Dept;
                    employeeEntity.Address = employee.Address;
                    var addMessageResult = _employeeService.UpdateEmployee(employeeEntity);
                    return Ok(addMessageResult);

                }
                else
                {

                    return Ok("not found");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpDelete("RemoveEmployee")]
        public async Task<IActionResult> Delete(EmployeeViewModel employee)
        {
            try
            {
                UPS.Domain.Domain.Employee employeeEntity = await _employeeService.GetByEmployeeName(employee.Name);
                if (employeeEntity != null)
                {
                    var addMessageResult = _employeeService.DeleteEmployee(employeeEntity);
                    return Ok(addMessageResult);

                }
                else
                {

                    return Ok("not found");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPost("SubmitEmployee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> SubmitEmployee(EmployeeViewModel employee)
        {
            try
            {
                Domain.Domain.Employee employeeEntity = new Domain.Domain.Employee()
                {
                    Name = employee.Name,
                    Dept = employee.Dept,
                    Address = employee.Address
                };
                var addMessageResult = await _employeeService.AddAsync(employeeEntity);
                return Ok(addMessageResult);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}