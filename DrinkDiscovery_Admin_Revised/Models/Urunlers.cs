using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Urunlers
    {
        [Key]
        public int urun_id { get; set; }
        public string urun_ad { get; set; }
        public byte[]? urun_resim { get; set; }
        public float urun_fiyat { get; set; }
        public string urun_icerik { get; set; }
        public string urun_malzemeler { get; set; }
        public float urun_puan { get; set; }
        public IList<Yorumlars> urun_yorumlar { get; set; }

        public IList<UrunlerYorumlars>? urun_yorumlari_s { get; set; }

        public bool display_slider { get; set; }

        //[ForeignKey("urun_kategori_id")]

        public int product_cat_id { get; set; }
        public UrunKategoris? urun_kategori { get; set; }

        // begeni
        //public ICollection<UrunYorumBegenme>? urun_begenmeler { get; set; }
    }
}
