using NuGet.Common;

namespace DrinkDiscovery_Admin.Models
{
    public interface IRepository
    {
        public IEnumerable<Iceceklers> repo_icecekler { get; }
        public IEnumerable<Urunlers> repo_urunler { get; }
        //IEnumerable<Kategori> repo_kategoriler { get; }
        public IEnumerable<Yorumlars> repo_yorumlar { get; }
        public IEnumerable<Kullanicilars> repo_kullanicilar { get; }
        public IEnumerable<Adminlers> repo_adminler { get; }

    }
}
