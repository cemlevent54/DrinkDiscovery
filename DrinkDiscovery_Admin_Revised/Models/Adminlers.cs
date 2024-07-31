using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Adminlers
    {
        [Key]
        public int admin_id { get; set; }
        public string admin_ad { get; set; }
        public string admin_sifre { get; set; }
        public byte[] admin_fotograf { get; set; }
    }
}
