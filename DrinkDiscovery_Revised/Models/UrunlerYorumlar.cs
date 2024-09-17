using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class UrunlerYorumlar
{
    public int YorumId { get; set; }

    public string? YorumIcerik { get; set; }

    public int? YorumPuan { get; set; }

    public DateTime? YorumTarih { get; set; }

    public string? YorumKullaniciId { get; set; }

    public bool? YorumOnay { get; set; }

    public int? YorumUrunurunId { get; set; }

    public int YorumDislikeCount { get; set; }

    public int YorumLikeCount { get; set; }

    public bool YorumLikeState { get; set; }

    public virtual Urunler? YorumUrunurun { get; set; }
}
