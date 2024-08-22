using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class IcecekYorumlars
    {
        [Key]
        public int yorum_id { get; set; }
        public string? yorum_icerik { get; set; }
        public int? yorum_puan { get; set; }
        public DateTime? yorum_tarih { get; set; }
        public string? yorum_kullanici_id { get; set; }
        public bool? yorum_onay { get; set; }
        public Iceceklers? yorum_icecek { get; set; }



    }
}
