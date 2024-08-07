using System;
using System.Collections.Generic;

namespace DrinkDiscovery.Models;

public partial class Urunler
{
    public int UrunId { get; set; }

    public string UrunAd { get; set; } = null!;

    public byte[]? UrunResim { get; set; }

    public float UrunFiyat { get; set; }

    public string UrunIcerik { get; set; } = null!;

    public string UrunMalzemeler { get; set; } = null!;

    public float UrunPuan { get; set; }

    public int? UrunKategoriId { get; set; }

    public int ProductCatId { get; set; }

    public bool DisplaySlider { get; set; }

    public virtual UrunKategoriler? UrunKategori { get; set; }

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
