using System;
using System.Collections.Generic;

namespace DrinkDiscovery_Revised.Models;

public partial class Kullanicilar
{
    public int KullaniciId { get; set; }

    public string KullaniciAd { get; set; } = null!;

    public string KullaniciSoyad { get; set; } = null!;

    public string KullaniciSifre { get; set; } = null!;

    public string KullaniciMail { get; set; } = null!;

    public string KullaniciTelefon { get; set; } = null!;

    public byte[] KullaniciFotograf { get; set; } = null!;

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
