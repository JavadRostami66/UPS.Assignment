using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Domain
{
    public class EmployeeContext : DbContext
    {
        //protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
        //{
        //    optionsbuilder.useinmemorydatabase(databasename: "employeedb");
        //    //loademployees();
        //}
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Domain.Employee> Employees { get; set; }

        public void LoadEmployees()
        {
            Domain.Employee employee = new Domain.Employee() { Id = 1, Name = "Javad", Dept = "department1" , Address = "ST num 1 , Torento"};
            Employees.Add(employee);
            employee = new Domain.Employee() { Id = 2, Name = "Mina", Dept = "department2", Address = "ST num 102 , Amesterdam" };
            Employees.Add(employee);
            this.SaveChanges();
        }

    }
}
