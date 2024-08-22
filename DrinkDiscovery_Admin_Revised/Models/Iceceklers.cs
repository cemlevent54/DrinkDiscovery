using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Iceceklers
    {
        [Key]
        public int icecek_id { get; set; }
        public string icecek_ad { get; set; }
        public byte[]? icecek_resim { get; set; }
        public float icecek_fiyat { get; set; }
        public string icecek_yapilis { get; set; }
        public string icecek_malzemeler { get; set; }
        public float icecek_puan { get; set; }
        public bool? haftanin_icecegi { get; set; }
        public IList<Yorumlars>? icecek_yorumlar { get; set; }

        public IList<IcecekYorumlars>? icecek_yorumlari_s { get; set; }


        
        public int beverage_cat_id { get; set; }
        public IcecekKategoris? icecek_kategori { get; set; }
    }
}
