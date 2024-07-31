﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DrinkDiscovery_Admin_Revised.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0PCHDQV;Initial Catalog=DrinkDiscovery_Admin;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Iceceklers> Icecekler { get; set; }
        public DbSet<Urunlers> Urunler { get; set; }
        public DbSet<Kullanicilars> Kullanicilar { get; set; }
        public DbSet<Yorumlars> Yorumlar { get; set; }
        public DbSet<Adminlers> Adminler { get; set; }
        public DbSet<IcecekKategoris> IcecekKategoriler { get; set; }
        public DbSet<UrunKategoris> UrunKategoriler { get; set; }
    }
}
