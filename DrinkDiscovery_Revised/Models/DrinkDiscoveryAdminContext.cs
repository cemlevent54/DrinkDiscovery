﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrinkDiscovery_Revised.Models;

public partial class DrinkDiscoveryAdminContext : DbContext
{
    public DrinkDiscoveryAdminContext()
    {
    }

    public DrinkDiscoveryAdminContext(DbContextOptions<DrinkDiscoveryAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adminler> Adminlers { get; set; }

    public virtual DbSet<IcecekKategoriler> IcecekKategorilers { get; set; }

    public virtual DbSet<IcecekYorumlar> IcecekYorumlars { get; set; }

    public virtual DbSet<Icecekler> Iceceklers { get; set; }

    public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<ShoppingCard> ShoppingCards { get; set; }

    public virtual DbSet<Tatlilar> Tatlilars { get; set; }

    public virtual DbSet<TatlilarKategoriler> TatlilarKategorilers { get; set; }

    public virtual DbSet<TatlilarYorumlar> TatlilarYorumlars { get; set; }

    public virtual DbSet<UrunKategoriler> UrunKategorilers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    public virtual DbSet<UrunlerYorumlar> UrunlerYorumlars { get; set; }

    public virtual DbSet<UserBeverageCommentAction> UserBeverageCommentActions { get; set; }

    public virtual DbSet<UserProductCommentAction> UserProductCommentActions { get; set; }

    public virtual DbSet<UserSweetCommentAction> UserSweetCommentActions { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5T6VOVK;Initial Catalog=DrinkDiscovery_Admin;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Adminler>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("Adminler");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminAd).HasColumnName("admin_ad");
            entity.Property(e => e.AdminFotograf).HasColumnName("admin_fotograf");
            entity.Property(e => e.AdminSifre).HasColumnName("admin_sifre");
        });

        modelBuilder.Entity<IcecekKategoriler>(entity =>
        {
            entity.HasKey(e => e.IcecekKategoriId);

            entity.ToTable("IcecekKategoriler");

            entity.Property(e => e.IcecekKategoriId).HasColumnName("icecek_kategori_id");
            entity.Property(e => e.IcecekKategoriAd).HasColumnName("icecek_kategori_ad");
        });

        modelBuilder.Entity<IcecekYorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.HasIndex(e => e.YorumIcecekicecekId, "IX_IcecekYorumlars_yorum_icecekicecek_id");

            entity.Property(e => e.YorumId).HasColumnName("yorum_id");
            entity.Property(e => e.YorumDislikeCount).HasColumnName("yorum_dislike_count");
            entity.Property(e => e.YorumIcecekicecekId).HasColumnName("yorum_icecekicecek_id");
            entity.Property(e => e.YorumIcerik).HasColumnName("yorum_icerik");
            entity.Property(e => e.YorumKullaniciId).HasColumnName("yorum_kullanici_id");
            entity.Property(e => e.YorumLikeCount).HasColumnName("yorum_like_count");
            entity.Property(e => e.YorumLikeState).HasColumnName("yorum_like_state");
            entity.Property(e => e.YorumOnay).HasColumnName("yorum_onay");
            entity.Property(e => e.YorumPuan).HasColumnName("yorum_puan");
            entity.Property(e => e.YorumTarih).HasColumnName("yorum_tarih");

            entity.HasOne(d => d.YorumIcecekicecek).WithMany(p => p.IcecekYorumlars).HasForeignKey(d => d.YorumIcecekicecekId);
        });

        modelBuilder.Entity<Icecekler>(entity =>
        {
            entity.HasKey(e => e.IcecekId);

            entity.ToTable("Icecekler");

            entity.HasIndex(e => e.IcecekKategoriId, "IX_Icecekler_icecek_kategori_id");

            entity.Property(e => e.IcecekId).HasColumnName("icecek_id");
            entity.Property(e => e.BeverageCatId).HasColumnName("beverage_cat_id");
            entity.Property(e => e.HaftaninIcecegi).HasColumnName("haftanin_icecegi");
            entity.Property(e => e.IcecekAd).HasColumnName("icecek_ad");
            entity.Property(e => e.IcecekFiyat).HasColumnName("icecek_fiyat");
            entity.Property(e => e.IcecekKategoriId).HasColumnName("icecek_kategori_id");
            entity.Property(e => e.IcecekMalzemeler).HasColumnName("icecek_malzemeler");
            entity.Property(e => e.IcecekPuan).HasColumnName("icecek_puan");
            entity.Property(e => e.IcecekResim).HasColumnName("icecek_resim");
            entity.Property(e => e.IcecekYapilis).HasColumnName("icecek_yapilis");

            entity.HasOne(d => d.IcecekKategori).WithMany(p => p.Iceceklers).HasForeignKey(d => d.IcecekKategoriId);
        });

        modelBuilder.Entity<Kullanicilar>(entity =>
        {
            entity.HasKey(e => e.KullaniciId);

            entity.ToTable("Kullanicilar");

            entity.Property(e => e.KullaniciId).HasColumnName("kullanici_id");
            entity.Property(e => e.KullaniciAd).HasColumnName("kullanici_ad");
            entity.Property(e => e.KullaniciFotograf).HasColumnName("kullanici_fotograf");
            entity.Property(e => e.KullaniciMail).HasColumnName("kullanici_mail");
            entity.Property(e => e.KullaniciSifre).HasColumnName("kullanici_sifre");
            entity.Property(e => e.KullaniciSoyad).HasColumnName("kullanici_soyad");
            entity.Property(e => e.KullaniciTelefon).HasColumnName("kullanici_telefon");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.OrderDeliveryAddress).HasColumnName("order_delivery_address");
            entity.Property(e => e.OrderPaymentMethod).HasColumnName("order_payment_method");
            entity.Property(e => e.OrderPaymentStatus).HasColumnName("order_payment_status");
            entity.Property(e => e.OrderShoppingCartStatus).HasColumnName("order_shopping_cart_status");
            entity.Property(e => e.OrderState).HasColumnName("order_state");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.OrderTotalPrice).HasColumnName("order_total_price");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderIdFk, "IX_OrderItem_order_id_fk");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderIdFk).HasColumnName("order_id_fk");
            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderPrice).HasColumnName("order_price");
            entity.Property(e => e.OrderProductCategoryId).HasColumnName("order_product_category_id");
            entity.Property(e => e.OrderProductId).HasColumnName("order_product_id");
            entity.Property(e => e.OrderQuantity).HasColumnName("order_quantity");

            entity.HasOne(d => d.OrderIdFkNavigation).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderIdFk);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.HasIndex(e => e.OrderIdFk, "IX_Payment_order_id_fk");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderIdFk).HasColumnName("order_id_fk");
            entity.Property(e => e.PaymentAmount).HasColumnName("payment_amount");
            entity.Property(e => e.PaymentCardCvv).HasColumnName("payment_card_cvv");
            entity.Property(e => e.PaymentCardExpiryDate).HasColumnName("payment_card_expiry_date");
            entity.Property(e => e.PaymentCardNumber).HasColumnName("payment_card_number");
            entity.Property(e => e.PaymentCartHolderName).HasColumnName("payment_cart_holder_name");
            entity.Property(e => e.PaymentConfirmation).HasColumnName("payment_confirmation");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.PaymentUserId).HasColumnName("payment_user_id");

            entity.HasOne(d => d.OrderIdFkNavigation).WithMany(p => p.Payments).HasForeignKey(d => d.OrderIdFk);
        });

        modelBuilder.Entity<ShoppingCard>(entity =>
        {
            entity.HasKey(e => e.CardId);

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Tatlilar>(entity =>
        {
            entity.HasKey(e => e.TatliId);

            entity.ToTable("Tatlilar");

            entity.HasIndex(e => e.TatliKategoriId, "IX_Tatlilar_tatli_kategori_id");

            entity.Property(e => e.TatliId).HasColumnName("tatli_id");
            entity.Property(e => e.Display).HasColumnName("display");
            entity.Property(e => e.TatliAciklama).HasColumnName("tatli_aciklama");
            entity.Property(e => e.TatliAd).HasColumnName("tatli_ad");
            entity.Property(e => e.TatliFiyat).HasColumnName("tatli_fiyat");
            entity.Property(e => e.TatliKategoriId).HasColumnName("tatli_kategori_id");
            entity.Property(e => e.TatliMalzemeler).HasColumnName("tatli_malzemeler");
            entity.Property(e => e.TatliPuan).HasColumnName("tatli_puan");
            entity.Property(e => e.TatliResim).HasColumnName("tatli_resim");
            entity.Property(e => e.TatliYapilis).HasColumnName("tatli_yapilis");

            entity.HasOne(d => d.TatliKategori).WithMany(p => p.Tatlilars).HasForeignKey(d => d.TatliKategoriId);
        });

        modelBuilder.Entity<TatlilarKategoriler>(entity =>
        {
            entity.HasKey(e => e.TatliKategoriId);

            entity.ToTable("TatlilarKategoriler");

            entity.Property(e => e.TatliKategoriId).HasColumnName("tatli_kategori_id");
            entity.Property(e => e.TatliKategoriAd).HasColumnName("tatli_kategori_ad");
        });

        modelBuilder.Entity<TatlilarYorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.HasIndex(e => e.YorumTatlitatliId, "IX_TatlilarYorumlars_yorum_tatlitatli_id");

            entity.Property(e => e.YorumId).HasColumnName("yorum_id");
            entity.Property(e => e.YorumDislikeCount).HasColumnName("yorum_dislike_count");
            entity.Property(e => e.YorumIcerik).HasColumnName("yorum_icerik");
            entity.Property(e => e.YorumKullaniciId).HasColumnName("yorum_kullanici_id");
            entity.Property(e => e.YorumLikeCount).HasColumnName("yorum_like_count");
            entity.Property(e => e.YorumLikeState).HasColumnName("yorum_like_state");
            entity.Property(e => e.YorumOnay).HasColumnName("yorum_onay");
            entity.Property(e => e.YorumPuan).HasColumnName("yorum_puan");
            entity.Property(e => e.YorumTarih).HasColumnName("yorum_tarih");
            entity.Property(e => e.YorumTatlitatliId).HasColumnName("yorum_tatlitatli_id");

            entity.HasOne(d => d.YorumTatlitatli).WithMany(p => p.TatlilarYorumlars).HasForeignKey(d => d.YorumTatlitatliId);
        });

        modelBuilder.Entity<UrunKategoriler>(entity =>
        {
            entity.HasKey(e => e.UrunKategoriId);

            entity.ToTable("UrunKategoriler");

            entity.Property(e => e.UrunKategoriId).HasColumnName("urun_kategori_id");
            entity.Property(e => e.UrunKategoriAd).HasColumnName("urun_kategori_ad");
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId);

            entity.ToTable("Urunler");

            entity.HasIndex(e => e.UrunKategoriId, "IX_Urunler_urun_kategori_id");

            entity.Property(e => e.UrunId).HasColumnName("urun_id");
            entity.Property(e => e.DisplaySlider).HasColumnName("display_slider");
            entity.Property(e => e.ProductCatId).HasColumnName("product_cat_id");
            entity.Property(e => e.UrunAd).HasColumnName("urun_ad");
            entity.Property(e => e.UrunFiyat).HasColumnName("urun_fiyat");
            entity.Property(e => e.UrunIcerik).HasColumnName("urun_icerik");
            entity.Property(e => e.UrunKategoriId).HasColumnName("urun_kategori_id");
            entity.Property(e => e.UrunMalzemeler).HasColumnName("urun_malzemeler");
            entity.Property(e => e.UrunPuan).HasColumnName("urun_puan");
            entity.Property(e => e.UrunResim).HasColumnName("urun_resim");

            entity.HasOne(d => d.UrunKategori).WithMany(p => p.Urunlers).HasForeignKey(d => d.UrunKategoriId);
        });

        modelBuilder.Entity<UrunlerYorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.HasIndex(e => e.YorumUrunurunId, "IX_UrunlerYorumlars_yorum_urunurun_id");

            entity.Property(e => e.YorumId).HasColumnName("yorum_id");
            entity.Property(e => e.YorumDislikeCount).HasColumnName("yorum_dislike_count");
            entity.Property(e => e.YorumIcerik).HasColumnName("yorum_icerik");
            entity.Property(e => e.YorumKullaniciId).HasColumnName("yorum_kullanici_id");
            entity.Property(e => e.YorumLikeCount).HasColumnName("yorum_like_count");
            entity.Property(e => e.YorumLikeState).HasColumnName("yorum_like_state");
            entity.Property(e => e.YorumOnay).HasColumnName("yorum_onay");
            entity.Property(e => e.YorumPuan).HasColumnName("yorum_puan");
            entity.Property(e => e.YorumTarih).HasColumnName("yorum_tarih");
            entity.Property(e => e.YorumUrunurunId).HasColumnName("yorum_urunurun_id");

            entity.HasOne(d => d.YorumUrunurun).WithMany(p => p.UrunlerYorumlars).HasForeignKey(d => d.YorumUrunurunId);
        });

        modelBuilder.Entity<UserBeverageCommentAction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.IsLiked).HasColumnName("is_liked");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserProductCommentAction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.IsLiked).HasColumnName("is_liked");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserSweetCommentAction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.IsLiked).HasColumnName("is_liked");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.ToTable("Yorumlar");

            entity.HasIndex(e => e.IceceklersicecekId, "IX_Yorumlar_Iceceklersicecek_id");

            entity.HasIndex(e => e.KullanicilarskullaniciId, "IX_Yorumlar_Kullanicilarskullanici_id");

            entity.HasIndex(e => e.TatlilarstatliId, "IX_Yorumlar_Tatlilarstatli_id");

            entity.HasIndex(e => e.UrunlersurunId, "IX_Yorumlar_Urunlersurun_id");

            entity.Property(e => e.YorumId).HasColumnName("yorum_id");
            entity.Property(e => e.IceceklersicecekId).HasColumnName("Iceceklersicecek_id");
            entity.Property(e => e.KullanicilarskullaniciId).HasColumnName("Kullanicilarskullanici_id");
            entity.Property(e => e.TatlilarstatliId).HasColumnName("Tatlilarstatli_id");
            entity.Property(e => e.UrunlersurunId).HasColumnName("Urunlersurun_id");
            entity.Property(e => e.YorumIcerik).HasColumnName("yorum_icerik");
            entity.Property(e => e.YorumKullaniciId).HasColumnName("yorum_kullanici_id");
            entity.Property(e => e.YorumPuan).HasColumnName("yorum_puan");
            entity.Property(e => e.YorumTarih).HasColumnName("yorum_tarih");
            entity.Property(e => e.YorumUrunId).HasColumnName("yorum_urun_id");

            entity.HasOne(d => d.Iceceklersicecek).WithMany(p => p.Yorumlars).HasForeignKey(d => d.IceceklersicecekId);

            entity.HasOne(d => d.Kullanicilarskullanici).WithMany(p => p.Yorumlars).HasForeignKey(d => d.KullanicilarskullaniciId);

            entity.HasOne(d => d.Tatlilarstatli).WithMany(p => p.Yorumlars).HasForeignKey(d => d.TatlilarstatliId);

            entity.HasOne(d => d.Urunlersurun).WithMany(p => p.Yorumlars).HasForeignKey(d => d.UrunlersurunId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
