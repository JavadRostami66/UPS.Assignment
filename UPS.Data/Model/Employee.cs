using Microsoft.EntityFrameworkCore;

using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;

using System.Threading.Tasks;

namespace empapi1.Models

{

    public class Employee

    {

        [Key]

        public int EmpId { get; set; }

        //Unique Identifier

        public string Name { get; set; }

        //Name of the employee

        public string Dept { get; set; }

        //Name of the employee

        public string Address { get; set; }

        //Name of the employee

    }

}

