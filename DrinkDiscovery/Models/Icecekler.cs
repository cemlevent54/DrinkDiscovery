using System;
using System.Collections.Generic;

namespace DrinkDiscovery.Models;

public partial class Icecekler
{
    public int IcecekId { get; set; }

    public string IcecekAd { get; set; } = null!;

    public byte[]? IcecekResim { get; set; }

    public float IcecekFiyat { get; set; }

    public string IcecekYapilis { get; set; } = null!;

    public string IcecekMalzemeler { get; set; } = null!;

    public float IcecekPuan { get; set; }

    public int? IcecekKategoriId { get; set; }

    public int BeverageCatId { get; set; }

    public bool? HaftaninIcecegi { get; set; }

    public virtual IcecekKategoriler? IcecekKategori { get; set; }

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
