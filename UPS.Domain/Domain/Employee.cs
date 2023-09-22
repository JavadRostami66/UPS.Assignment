using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.Domain.Common;

namespace UPS.Domain.Domain
{

    public class Employee : Entity<int>
    {

        [Column("Name")]
        [Required]
        public string Name { get; set; }

        //Name of the employee
        [Column("Dept")]
        [Required]
        public string Dept { get; set; }

        //Dept of the employee
        [Column("Address")]
        public string Address { get; set; }

        //Address of the employee

    }
}
