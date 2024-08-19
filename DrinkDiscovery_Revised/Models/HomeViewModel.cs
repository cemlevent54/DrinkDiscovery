namespace DrinkDiscovery_Revised.Models
{
    public class HomeViewModel
    {
        // layout a model ekleyeceğim kullanacaklarımın hepsini burada toplamam gerekiyor
        private IRepository repository;
        public IQueryable<DrinkDiscovery_Revised.Models.UrunKategoriler> UrunKategoriler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.IcecekKategoriler> IcecekKategoriler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.TatlilarKategoriler> TatlilarKategoriler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Icecekler> HaftaninIcecekleri { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Urunler> Urunler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Icecekler> Icecekler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Tatlilar> Tatlilar { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Adminler> Adminler { get; set; }
        public IQueryable<DrinkDiscovery_Revised.Models.Kullanicilar> Kullanicilar { get; set; }

        public Kullanicilar Kullanicilar_ { get; set; }


        public HomeViewModel(IRepository repository)
        {
            UrunKategoriler = repository.UrunKategoriler;
            IcecekKategoriler = repository.IcecekKategoriler;
            TatlilarKategoriler = repository.TatlilarKategoriler;
            HaftaninIcecekleri = repository.Icecekler;
            Urunler = repository.Urunler;
            Icecekler = repository.Icecekler;
            Tatlilar = repository.Tatlilar;
            Adminler = repository.Adminler;
            Kullanicilar = repository.Kullanicilar;
            Kullanicilar_ = new Kullanicilar();
        }


    }
}
