using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class Yorumlar
{
    public int YorumId { get; set; }

    public string YorumIcerik { get; set; } = null!;

    public int YorumPuan { get; set; }

    public DateTime YorumTarih { get; set; }

    public int YorumKullaniciId { get; set; }

    public int YorumUrunId { get; set; }

    public int? IceceklersicecekId { get; set; }

    public int? KullanicilarskullaniciId { get; set; }

    public int? UrunlersurunId { get; set; }

    public int? TatlilarstatliId { get; set; }

    public virtual Icecekler? Iceceklersicecek { get; set; }

    public virtual Kullanicilar? Kullanicilarskullanici { get; set; }

    public virtual Tatlilar? Tatlilarstatli { get; set; }

    public virtual Urunler? Urunlersurun { get; set; }
}
