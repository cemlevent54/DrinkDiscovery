using System.ComponentModel.DataAnnotations;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Kullanicilars
    {
        [Key]
        public int kullanici_id { get; set; }
        public string kullanici_ad { get; set; }
        public string kullanici_soyad { get; set; }
        public string kullanici_sifre { get; set; }
        public string kullanici_mail { get; set; }
        public string kullanici_telefon { get; set; }
        public byte[] kullanici_fotograf { get; set; }

        public IList<Yorumlars> kullanici_yorumlar { get; set; }
    }
}
