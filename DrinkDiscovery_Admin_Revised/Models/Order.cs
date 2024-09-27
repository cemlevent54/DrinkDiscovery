using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public string? user_id { get; set; }
        public DateTime? order_date { get; set; }
        public float? order_total_price { get; set; }
        public string? order_state { get; set; }
        public string? order_delivery_address { get; set; }
        public string? order_payment_method { get; set; } // card default
        public string? order_payment_status { get; set; } // paid default . after sending confirmation email, change to confirmed
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? order_status { get; set; }
        public bool order_shopping_cart_status { get; set; } // if 0, normal card. if 1, you have already confirm your card and navigate it to order page.
        public ICollection<OrderItem>? order_items { get; set; }

    }
}
