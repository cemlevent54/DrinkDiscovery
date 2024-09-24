using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int order_item_id { get; set; }
        public int order_id { get; set; }
        public int order_product_id { get; set; }
        public int order_product_category_id { get; set; }
        public int order_quantity { get; set; }
        public float order_price { get; set; }
        public Order? order { get; set; }
    }
}
