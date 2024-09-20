using DrinkDiscovery_Admin_Revised.Areas.Identity.Data;
using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Admin_Revised.Areas.Identity.Data;

public class DrinkDiscovery_Admin_Revised_Context : IdentityDbContext<DrinkDiscovery_Admin_Revised_User>
{
    public DrinkDiscovery_Admin_Revised_Context(DbContextOptions<DrinkDiscovery_Admin_Revised_Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<DrinkDiscovery_Admin_Revised_User> Users { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<DrinkDiscovery_Admin_Revised_User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DrinkDiscovery_Admin_Revised_User> builder)
    {
        builder.Property(p => p.kullanici_ad).HasColumnName("KullaniciAd").HasMaxLength(50);
        builder.Property(p => p.kullanici_soyad).HasColumnName("KullaniciSoyad").HasMaxLength(50);
        builder.Property(p => p.kullanici_sifre).HasColumnName("KullaniciSifre").HasMaxLength(50);
        builder.Property(p => p.kullanici_mail).HasColumnName("KullaniciMail").HasMaxLength(50);
        builder.Property(p => p.kullanici_telefon).HasColumnName("KullaniciTelefon").HasMaxLength(50);
        builder.Property(p => p.kullanici_fotograf).HasColumnName("KullaniciFotograf").HasColumnType("varbinary(max)");
        builder.Property(p => p.kullanici_username).HasColumnName("KullaniciUsername").HasMaxLength(50);
        //builder.Property(p => p.kullanici_fotograf_file).HasColumnName("KullaniciFotografFile");

    }
}
