using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Service.ViewModel.Employee
{
    public class EmployeeViewModel
    {
        [Required]
        public string Name { get; set; }

        //Name of the employee
        [Required]
        public string Dept { get; set; }

        //Dept of the employee
        public string Address { get; set; }

        //Address of the employee
    }
}
