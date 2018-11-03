using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Model
{
    public class DeliveryType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Provider { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsCOD { get; set; }
    }
}
