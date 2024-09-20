using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // sql server changed
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5T6VOVK;Initial Catalog=DrinkDiscovery_Admin;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Iceceklers> Icecekler { get; set; }
        public DbSet<Urunlers> Urunler { get; set; }
        public DbSet<Kullanicilars> Kullanicilar { get; set; }
        public DbSet<Yorumlars> Yorumlar { get; set; }
        public DbSet<Adminlers> Adminler { get; set; }
        public DbSet<IcecekKategoris> IcecekKategoriler { get; set; }
        public DbSet<UrunKategoris> UrunKategoriler { get; set; }
        public DbSet<Tatlilars> Tatlilar { get; set; }
        public DbSet<TatlilarKategoris> TatlilarKategoriler { get; set; }

        // comment and comment responses
        public DbSet<UserBeverageCommentActions> UserBeverageCommentActions { get; set; }
        public DbSet<UserSweetCommentActions> UserSweetCommentActions { get; set; }
        public DbSet<UserProductCommentActions> UserProductCommentActions { get; set; }

        public DbSet<IcecekYorumlars> IcecekYorumlars { get; set; }
        public DbSet<UrunlerYorumlars> UrunlerYorumlars { get; set; }
        public DbSet<TatlilarYorumlars> TatlilarYorumlars { get; set; }


    }
}
