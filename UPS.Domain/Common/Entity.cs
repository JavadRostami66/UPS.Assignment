using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.Domain.Common
{

        public class Entity<TKey> : IEntity<TKey>
        {
            [Key]
            [Column("Id")]
            public TKey Id { get; set; }
        }

}

