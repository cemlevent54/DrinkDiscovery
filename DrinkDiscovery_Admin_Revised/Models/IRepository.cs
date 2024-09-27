using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using System.Linq.Expressions;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public interface IRepository
    {
        public IQueryable<Iceceklers> Icecekler { get; }
        public IQueryable<Urunlers> Urunler { get; }
        public IQueryable<Kullanicilars> Kullanicilar { get; }
        public IQueryable<Yorumlars> Yorumlar { get; }
        public IQueryable<Adminlers> Adminler { get; }
        public IQueryable<IcecekKategoris> IcecekKategoriler { get; }
        public IQueryable<UrunKategoris> UrunKategoriler { get; }
        public IQueryable<Tatlilars> Tatlilar { get; }
        public IQueryable<TatlilarKategoris> TatlilarKategoriler { get; }
        public IQueryable<DrinkDiscovery_Admin_Revised_User> Users { get; }

        // yorumlar 
        public IQueryable<IcecekYorumlars> IcecekYorumlars { get; }
        public IQueryable<UrunlerYorumlars> UrunlerYorumlars { get; }
        public IQueryable<TatlilarYorumlars> TatlilarYorumlars { get; }

        // yorum response
        public IQueryable<UserBeverageCommentActions> UserBeverageCommentActions { get; }
        public IQueryable<UserSweetCommentActions> UserSweetCommentActions { get; }
        public IQueryable<UserProductCommentActions> UserProductCommentActions { get; }

        // card
        public IQueryable<ShoppingCards> ShoppingCards { get; }
        public IQueryable<Order> Order { get; }
        public IQueryable<OrderItem> OrderItem { get; }
        public IQueryable<Payment> Payment { get; }






        public void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        //void UpdateBool<T>(T entity) where T : class;
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

        // user
        public void UpdateUser(DrinkDiscovery_Admin_Revised_User user);

        public void SaveChangesUser();

        public void DeleteUser(DrinkDiscovery_Admin_Revised_User user);
    }
}
