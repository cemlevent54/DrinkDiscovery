using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin.Models
{
    public class IcecekKategoris
    {
        [Key]
        public int icecek_kategori_id { get; set; }
        public string icecek_kategori_ad { get; set; }
        public IList<Iceceklers>? icecekler { get; set; }
    }
}
