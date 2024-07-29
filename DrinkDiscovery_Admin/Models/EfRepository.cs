using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DrinkDiscovery_Admin.Models
{
    public class EfRepository : IRepository
    {
        private Context context;
        public EfRepository(Context _context)
        {
            context = _context;
        }
        public IQueryable<Adminlers> Adminler => context.Adminler;
        public IQueryable<Iceceklers> Icecekler => context.Icecekler;
        public IQueryable<Kullanicilars> Kullanicilar => context.Kullanicilar;
        public IQueryable<Urunlers> Urunler => context.Urunler;
        public IQueryable<Yorumlars> Yorumlar => context.Yorumlar;

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
    }
}
