using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public float PaymentAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public bool PaymentConfirmation { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? PaymentCartHolderName { get; set; }

    public string? PaymentCardNumber { get; set; }

    public string? PaymentCardExpiryDate { get; set; }

    public string? PaymentCardCvv { get; set; }

    public int? OrderIdFk { get; set; }

    public string? PaymentUserId { get; set; }

    public virtual Order? OrderIdFkNavigation { get; set; }
}
