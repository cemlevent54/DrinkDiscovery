using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public float? OrderTotalPrice { get; set; }

    public string? Email { get; set; }

    public string? OrderDeliveryAddress { get; set; }

    public string? OrderPaymentMethod { get; set; }

    public string? OrderPaymentStatus { get; set; }

    public string? OrderStatus { get; set; }

    public string? PhoneNumber { get; set; }

    public bool OrderShoppingCartStatus { get; set; }

    public string? OrderState { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
