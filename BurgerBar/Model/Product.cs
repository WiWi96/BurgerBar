using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerBar.Model
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsInMenu { get; set; }

        public CreationType CreationType { get; set; }
    }
}