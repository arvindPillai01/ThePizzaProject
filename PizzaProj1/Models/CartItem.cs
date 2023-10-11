using System.ComponentModel.DataAnnotations;

namespace PizzaProj1.Models
{
    public class CartItem
    {
            [Key]  // Specify CartId as the primary key
        
            public int CartId { get; set; }
            public int PizzaId { get; set; }
            public int Quantity { get; set; }
            public string UserId { get; set; }

            public virtual PizzaItem Pizza { get; set; }
    }
}
