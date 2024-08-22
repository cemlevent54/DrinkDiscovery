using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Tatlilars
    {
        [Key]
        public int tatli_id { get; set; }
        public string? tatli_ad { get; set; }
        public byte[]? tatli_resim { get; set; }
        public string? tatli_aciklama { get; set; }
        public float? tatli_fiyat { get; set; }
        public float? tatli_puan { get; set; }
        public string? tatli_malzemeler { get; set; }
        public string? tatli_yapilis { get; set; }

        public bool display { get; set; }

        public IList<Yorumlars>? tatli_yorumlar { get; set; }

        public IList<TatlilarYorumlars>? tatli_yorumlari_s { get; set; }
        public TatlilarKategoris? tatli_kategori { get; set; }

    }
}
