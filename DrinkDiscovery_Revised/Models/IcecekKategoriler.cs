using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class IcecekKategoriler
{
    public int IcecekKategoriId { get; set; }

    public string IcecekKategoriAd { get; set; } = null!;

    public virtual ICollection<Icecekler> Iceceklers { get; set; } = new List<Icecekler>();
}
