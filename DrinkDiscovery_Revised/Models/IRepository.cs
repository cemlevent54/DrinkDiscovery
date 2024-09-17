using System.Linq.Expressions;

namespace DrinkDiscovery_Revised.Models
{
    public interface IRepository
    {
        public IQueryable<Icecekler> Icecekler { get; }
        public IQueryable<Urunler> Urunler { get; }
        public IQueryable<Kullanicilar> Kullanicilar { get; }
        public IQueryable<Yorumlar> Yorumlar { get; }
        public IQueryable<Adminler> Adminler { get; }
        public IQueryable<IcecekKategoriler> IcecekKategoriler { get; }
        public IQueryable<UrunKategoriler> UrunKategoriler { get; }
        public IQueryable<Tatlilar> Tatlilar { get; }
        public IQueryable<TatlilarKategoriler> TatlilarKategoriler { get; }

        // yorum tabloları
        public IQueryable<IcecekYorumlar> IcecekYorumlar { get; }
        public IQueryable<UrunlerYorumlar> UrunYorumlar { get; }
        public IQueryable<TatlilarYorumlar> TatlilarYorumlar { get; }

        // yorum begeni tabloları
        public IQueryable<UserBeverageCommentAction> UserBeverageCommentAction { get; }
        public IQueryable<UserSweetCommentAction> UserSweetCommentAction { get; }
        public IQueryable<UserProductCommentAction> UserProductCommentAction { get; }

        




        public IEnumerable<UrunKategoriler> GetUrunKategoriler();
        public IEnumerable<TatlilarKategoriler> GetTatlilarKategoriler();
        public IEnumerable<IcecekKategoriler> GetIcecekKategoriler();
        public IEnumerable<Icecekler> GetHaftaninIcecekleri();
        public IEnumerable<Urunler> GetUrunler();

        public Dictionary<string, int> GetIcecekIsimleri();



        public void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void SaveChanges();
        void DeleteAll();
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class;

        // async 
        Task AddAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();
        Task DeleteAllAsync();
        Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
