using System.ComponentModel.DataAnnotations;

namespace PizzaProj1.Models
{
    public class PizzaItem
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set;}
    }
}
