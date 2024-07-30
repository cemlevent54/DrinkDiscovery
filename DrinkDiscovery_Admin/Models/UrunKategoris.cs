
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace DrinkDiscovery_Admin.Models
{
    public class UrunKategoris
    {
        [Key]
        public int urun_kategori_id { get; set; }
        public string urun_kategori_ad { get; set; }
        public IList<Urunlers>? urunler { get; set; }
    }
}
