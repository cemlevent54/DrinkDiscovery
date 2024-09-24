using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class ShoppingCard
{
    public int CardId { get; set; }

    public string? UserId { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public int Count { get; set; }
}
