using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using System.Linq.Expressions;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class EfRepository : IRepository
    {
        private Context context;
        private DrinkDiscovery_Admin_Revised_Context user_context;

        public EfRepository(Context _context, DrinkDiscovery_Admin_Revised_Context _user_context)
        {
            context = _context;
            user_context= _user_context;
        }
        public IQueryable<Adminlers> Adminler => context.Adminler;
        public IQueryable<Iceceklers> Icecekler => context.Icecekler;
        public IQueryable<Kullanicilars> Kullanicilar => context.Kullanicilar;
        public IQueryable<Urunlers> Urunler => context.Urunler;
        public IQueryable<Yorumlars> Yorumlar => context.Yorumlar;
        public IQueryable<IcecekKategoris> IcecekKategoriler => context.IcecekKategoriler;
        public IQueryable<UrunKategoris> UrunKategoriler => context.UrunKategoriler;
        public IQueryable<Tatlilars> Tatlilar => context.Tatlilar;
        public IQueryable<TatlilarKategoris> TatlilarKategoriler => context.TatlilarKategoriler;

        public IQueryable<DrinkDiscovery_Admin_Revised_User> Users => user_context.Users;


        // yorumlar 
        public IQueryable<IcecekYorumlars> IcecekYorumlars => context.IcecekYorumlars;
        public IQueryable<UrunlerYorumlars> UrunlerYorumlars => context.UrunlerYorumlars;
        public IQueryable<TatlilarYorumlars> TatlilarYorumlars => context.TatlilarYorumlars;

        // yorum response
        public IQueryable<UserBeverageCommentActions> UserBeverageCommentActions => context.UserBeverageCommentActions;
        public IQueryable<UserSweetCommentActions> UserSweetCommentActions => context.UserSweetCommentActions;
        public IQueryable<UserProductCommentActions> UserProductCommentActions => context.UserProductCommentActions;




        public void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().Where(predicate);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IQueryable<T> sinif<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            context.Set<T>().Update(entity);
            SaveChanges();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await context.Set<T>().AddAsync(entity);
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            //var resultList = await context.Set<T>().Where(predicate).ToListAsync();
            //return resultList.AsQueryable();
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(DrinkDiscovery_Admin_Revised_User user)
        {
            user_context.Users.Update(user);
        }

        public void SaveChangesUser()
        {
            user_context.SaveChanges();
        }

        public void DeleteUser(DrinkDiscovery_Admin_Revised_User user)
        {
            user_context.Users.Remove(user);
            SaveChangesUser();
        }
    }
}
