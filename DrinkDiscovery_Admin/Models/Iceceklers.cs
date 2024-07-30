using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkDiscovery_Admin.Models
{
    public class Iceceklers
    {
        [Key]
        public int icecek_id { get; set; }
        public string icecek_ad { get; set; }
        public byte[]? icecek_resim { get; set; }
        public int icecek_fiyat { get; set; }
        public string icecek_icerik { get; set; }
        public string icecek_malzemeler { get; set; }
        public string icecek_puan { get; set; }
        public IList<Yorumlars>? icecek_yorumlar { get; set; }


        [ForeignKey("icecek_kategori_id")]
        public IcecekKategoris? icecek_kategori { get; set; }
        


    }
}
