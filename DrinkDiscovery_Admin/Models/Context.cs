using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DrinkDiscovery_Admin.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0PCHDQV;Initial Catalog=Db_DrinkDiscovery;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Iceceklers> Icecekler { get; set; }
        public DbSet<Urunlers> Urunler { get; set; }
        public DbSet<Kullanicilars> Kullanicilar { get; set; }
        public DbSet<Yorumlars> Yorumlar { get; set; }

        public DbSet<Adminlers> Adminler { get; set; }
    }
}
