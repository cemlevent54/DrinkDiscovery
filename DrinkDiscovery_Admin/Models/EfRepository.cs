using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkDiscovery_Admin.Models;


namespace DrinkDiscovery_Admin.Models
{
    public class EfRepository : IRepository
    {
        private Context context;
        public EfRepository(Context _context)
        {
            context = _context;
        }
        public IEnumerable<Iceceklers> repo_icecekler => context.Icecekler;
        public IEnumerable<Urunlers> repo_urunler => context.Urunler;
        public IEnumerable<Yorumlars> repo_yorumlar => context.Yorumlar;
        public IEnumerable<Kullanicilars> repo_kullanicilar => context.Kullanicilar;
        public IEnumerable<Adminlers> repo_adminler => context.Adminler;
    }
}
