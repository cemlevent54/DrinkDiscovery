using System;
using System.Collections.Generic;

namespace DrinkDiscovery.Models;

public partial class UrunKategoriler
{
    public int UrunKategoriId { get; set; }

    public string UrunKategoriAd { get; set; } = null!;

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
