using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class ShoppingCards
    {
        [Key]
        public int card_id { get; set; }
        public string? user_id { get; set; }
        public int product_id { get; set; }
        public int category_id { get; set; }
        public int count { get; set; }
    }
}
