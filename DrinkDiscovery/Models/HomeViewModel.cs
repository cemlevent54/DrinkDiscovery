namespace DrinkDiscovery.Models
{
    public class HomeViewModel
    {
        private IRepository repository;
        public IEnumerable<DrinkDiscovery.Models.UrunKategoriler> UrunKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.IcecekKategoriler> IcecekKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.TatlilarKategoriler> TatlilarKategoriler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Icecekler> HaftaninIcecekleri { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Urunler> Urunler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Icecekler> Icecekler { get; set; }
        public IEnumerable<DrinkDiscovery.Models.Tatlilar> Tatlilar { get; set; }

        public HomeViewModel(IRepository repository)
        {
            UrunKategoriler = repository.UrunKategoriler;
            IcecekKategoriler = repository.IcecekKategoriler;
            TatlilarKategoriler = repository.TatlilarKategoriler;
            HaftaninIcecekleri = repository.Icecekler;
            Urunler = repository.Urunler;
            Icecekler = repository.Icecekler;
            Tatlilar = repository.Tatlilar;
        }
    }
}
