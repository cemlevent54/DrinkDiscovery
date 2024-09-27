using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public string? payment_user_id { get; set; }
        public int order_id { get; set; }
        public float payment_amount { get; set; }
        public string? payment_method { get; set; }
        public string? payment_status { get; set; }
        public bool payment_confirmation { get; set; }
        public DateTime payment_date { get; set; }
        public string? payment_cart_holder_name { get; set; }
        public string? payment_card_number { get; set; }
        public string? payment_card_expiry_date { get; set; }
        public string? payment_card_cvv { get; set; }


        // related to order
        [ForeignKey("order_id_fk")]
        public Order? order { get; set; }
    }
}
