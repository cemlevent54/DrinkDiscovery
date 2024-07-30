using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkDiscovery_Admin.Models
{
    public class Urunlers
    {
        [Key]
        public int urun_id { get; set; }
        public string urun_ad { get; set; }
        public byte[] urun_resim { get; set; }
        public int urun_fiyat { get; set; }
        public string urun_icerik { get; set; }
        public string urun_malzemeler { get; set; }
        public int urun_puan { get; set; }
        public IList<Yorumlars> urun_yorumlar { get; set; }
        
        [ForeignKey("urun_kategori_id")]
        public UrunKategoris? urun_kategori { get; set; }


    }
}
