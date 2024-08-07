using System;
using System.Collections.Generic;

namespace DrinkDiscovery.Models;

public partial class Tatlilar
{
    public int TatliId { get; set; }

    public string? TatliAd { get; set; }

    public string? TatliAciklama { get; set; }

    public float? TatliFiyat { get; set; }

    public float? TatliPuan { get; set; }

    public string? TatliMalzemeler { get; set; }

    public string? TatliYapilis { get; set; }

    public int? TatliKategoriId { get; set; }

    public byte[]? TatliResim { get; set; }

    public bool Display { get; set; }

    public virtual TatlilarKategoriler? TatliKategori { get; set; }

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
