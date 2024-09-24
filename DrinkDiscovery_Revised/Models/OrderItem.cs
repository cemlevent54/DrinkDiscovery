using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int OrderProductId { get; set; }

    public int OrderProductCategoryId { get; set; }

    public int OrderQuantity { get; set; }

    public float OrderPrice { get; set; }

    public int? OrderIdFk { get; set; }

    public virtual Order? OrderIdFkNavigation { get; set; }
}
