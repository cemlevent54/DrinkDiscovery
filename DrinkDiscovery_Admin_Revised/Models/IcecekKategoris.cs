using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class IcecekKategoris
    {
        [Key]
        public int icecek_kategori_id { get; set; }
        public string icecek_kategori_ad { get; set; }
        public IList<Iceceklers>? Iceceklers { get; set; }
    }
}
