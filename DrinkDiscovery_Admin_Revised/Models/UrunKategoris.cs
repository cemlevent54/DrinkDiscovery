using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class UrunKategoris
    {
        [Key]
        public int urun_kategori_id { get; set; }
        public string urun_kategori_ad { get; set; }
        public IList<Urunlers>? urunler { get; set; }
    }
}
