using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class TatlilarYorumlar
{
    public int YorumId { get; set; }

    public string? YorumIcerik { get; set; }

    public int? YorumPuan { get; set; }

    public DateTime? YorumTarih { get; set; }

    public string? YorumKullaniciId { get; set; }

    public bool? YorumOnay { get; set; }

    public int? YorumTatlitatliId { get; set; }

    public virtual Tatlilar? YorumTatlitatli { get; set; }
}
