using System.Linq.Expressions;

namespace DrinkDiscovery_Revised.Models
{
    public class EfRepository : IRepository
    {
        private DrinkDiscoveryAdminContext context;

        public EfRepository(DrinkDiscoveryAdminContext _context)
        {
            context = _context;
        }
        public IQueryable<Adminler> Adminler => context.Adminlers;
        public IQueryable<Icecekler> Icecekler => context.Iceceklers;
        public IQueryable<Kullanicilar> Kullanicilar => context.Kullanicilars;
        public IQueryable<Urunler> Urunler => context.Urunlers;
        public IQueryable<Yorumlar> Yorumlar => context.Yorumlars;
        public IQueryable<IcecekKategoriler> IcecekKategoriler => context.IcecekKategorilers;
        public IQueryable<UrunKategoriler> UrunKategoriler => context.UrunKategorilers;
        public IQueryable<Tatlilar> Tatlilar => context.Tatlilars;
        public IQueryable<TatlilarKategoriler> TatlilarKategoriler => context.TatlilarKategorilers;

        public IEnumerable<UrunKategoriler> GetUrunKategoriler()
        {
            return context.UrunKategorilers.ToList();
        }
        public IEnumerable<TatlilarKategoriler> GetTatlilarKategoriler()
        {
            return context.TatlilarKategorilers.ToList();
        }
        public IEnumerable<IcecekKategoriler> GetIcecekKategoriler()
        {
            return context.IcecekKategorilers.ToList();
        }
        public IEnumerable<Icecekler> GetHaftaninIcecekleri()
        {
            return context.Iceceklers.Where(i => i.HaftaninIcecegi == true).ToList();
        }
        public IEnumerable<Urunler> GetUrunler()
        {
            return context.Urunlers.ToList();
        }
        public Dictionary<string, int> GetIcecekIsimleri()
        {
            return context.Iceceklers.ToDictionary(i => i.IcecekAd, i => i.IcecekId);
        }

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
