using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class TatlilarKategoris
    {
        [Key]
        public int tatli_kategori_id { get; set; }
        public string? tatli_kategori_ad { get; set; }
        public IList<Tatlilars>? Tatlilars { get; set; }

    }
}
