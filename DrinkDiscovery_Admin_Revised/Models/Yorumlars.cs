using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Yorumlars
    {
        [Key]
        public int yorum_id { get; set; }
        public string yorum_icerik { get; set; }
        public int yorum_puan { get; set; }
        public DateTime yorum_tarih { get; set; }
        public int yorum_kullanici_id { get; set; }
        public int yorum_urun_id { get; set; }
    }
}
