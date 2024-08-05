using System;
using System.Collections.Generic;

namespace DrinkDiscovery.Models;

public partial class TatlilarKategoriler
{
    public int TatliKategoriId { get; set; }

    public string? TatliKategoriAd { get; set; }

    public virtual ICollection<Tatlilar> Tatlilars { get; set; } = new List<Tatlilar>();
}
