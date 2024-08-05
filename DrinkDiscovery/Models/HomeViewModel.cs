namespace DrinkDiscovery.Models
{
    public class HomeViewModel
    {
        public IEnumerable<DrinkDiscovery.Models.UrunKategoriler> UrunKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.IcecekKategoriler> IcecekKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.TatlilarKategoriler> TatlilarKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Icecekler> HaftaninIcecekleri { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Urunler> Urunler { get; set; }
    }
}
