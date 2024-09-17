﻿// <auto-generated />
using System;
using DrinkDiscovery_Admin_Revised.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240916221737_add_comment_actions_beverage")]
    partial class add_comment_actions_beverage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Adminlers", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("admin_fotograf")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("admin_sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.IcecekKategoris", b =>
                {
                    b.Property<int>("icecek_kategori_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("icecek_kategori_id"));

                    b.Property<string>("icecek_kategori_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("icecek_kategori_id");

                    b.ToTable("IcecekKategoriler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.IcecekYorumlars", b =>
                {
                    b.Property<int>("yorum_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yorum_id"));

                    b.Property<int>("yorum_dislike_count")
                        .HasColumnType("int");

                    b.Property<int?>("yorum_icecekicecek_id")
                        .HasColumnType("int");

                    b.Property<string>("yorum_icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yorum_kullanici_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yorum_like_count")
                        .HasColumnType("int");

                    b.Property<bool>("yorum_like_state")
                        .HasColumnType("bit");

                    b.Property<bool?>("yorum_onay")
                        .HasColumnType("bit");

                    b.Property<int?>("yorum_puan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("yorum_tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("yorum_id");

                    b.HasIndex("yorum_icecekicecek_id");

                    b.ToTable("IcecekYorumlars");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Iceceklers", b =>
                {
                    b.Property<int>("icecek_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("icecek_id"));

                    b.Property<int>("beverage_cat_id")
                        .HasColumnType("int");

                    b.Property<bool?>("haftanin_icecegi")
                        .HasColumnType("bit");

                    b.Property<string>("icecek_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("icecek_fiyat")
                        .HasColumnType("real");

                    b.Property<int?>("icecek_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("icecek_malzemeler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("icecek_puan")
                        .HasColumnType("real");

                    b.Property<byte[]>("icecek_resim")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("icecek_yapilis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("icecek_id");

                    b.HasIndex("icecek_kategori_id");

                    b.ToTable("Icecekler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Kullanicilars", b =>
                {
                    b.Property<int>("kullanici_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kullanici_id"));

                    b.Property<string>("kullanici_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("kullanici_fotograf")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("kullanici_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kullanici_sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kullanici_soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kullanici_telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kullanici_id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.TatlilarKategoris", b =>
                {
                    b.Property<int>("tatli_kategori_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tatli_kategori_id"));

                    b.Property<string>("tatli_kategori_ad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tatli_kategori_id");

                    b.ToTable("TatlilarKategoriler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.TatlilarYorumlars", b =>
                {
                    b.Property<int>("yorum_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yorum_id"));

                    b.Property<string>("yorum_icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yorum_kullanici_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("yorum_onay")
                        .HasColumnType("bit");

                    b.Property<int?>("yorum_puan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("yorum_tarih")
                        .HasColumnType("datetime2");

                    b.Property<int?>("yorum_tatlitatli_id")
                        .HasColumnType("int");

                    b.HasKey("yorum_id");

                    b.HasIndex("yorum_tatlitatli_id");

                    b.ToTable("TatlilarYorumlars");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Tatlilars", b =>
                {
                    b.Property<int>("tatli_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tatli_id"));

                    b.Property<bool>("display")
                        .HasColumnType("bit");

                    b.Property<string>("tatli_aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tatli_ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("tatli_fiyat")
                        .HasColumnType("real");

                    b.Property<int?>("tatli_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("tatli_malzemeler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("tatli_puan")
                        .HasColumnType("real");

                    b.Property<byte[]>("tatli_resim")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("tatli_yapilis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tatli_id");

                    b.HasIndex("tatli_kategori_id");

                    b.ToTable("Tatlilar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.UrunKategoris", b =>
                {
                    b.Property<int>("urun_kategori_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urun_kategori_id"));

                    b.Property<string>("urun_kategori_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("urun_kategori_id");

                    b.ToTable("UrunKategoriler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.UrunlerYorumlars", b =>
                {
                    b.Property<int>("yorum_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yorum_id"));

                    b.Property<string>("yorum_icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yorum_kullanici_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("yorum_onay")
                        .HasColumnType("bit");

                    b.Property<int?>("yorum_puan")
                        .HasColumnType("int");

                    b.Property<DateTime?>("yorum_tarih")
                        .HasColumnType("datetime2");

                    b.Property<int?>("yorum_urunurun_id")
                        .HasColumnType("int");

                    b.HasKey("yorum_id");

                    b.HasIndex("yorum_urunurun_id");

                    b.ToTable("UrunlerYorumlars");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Urunlers", b =>
                {
                    b.Property<int>("urun_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urun_id"));

                    b.Property<bool>("display_slider")
                        .HasColumnType("bit");

                    b.Property<int>("product_cat_id")
                        .HasColumnType("int");

                    b.Property<string>("urun_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("urun_fiyat")
                        .HasColumnType("real");

                    b.Property<string>("urun_icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("urun_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("urun_malzemeler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("urun_puan")
                        .HasColumnType("real");

                    b.Property<byte[]>("urun_resim")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("urun_id");

                    b.HasIndex("urun_kategori_id");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.UserBeverageCommentActions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("comment_id")
                        .HasColumnType("int");

                    b.Property<bool>("is_liked")
                        .HasColumnType("bit");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("UserBeverageCommentActions");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Yorumlars", b =>
                {
                    b.Property<int>("yorum_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yorum_id"));

                    b.Property<int?>("Iceceklersicecek_id")
                        .HasColumnType("int");

                    b.Property<int?>("Kullanicilarskullanici_id")
                        .HasColumnType("int");

                    b.Property<int?>("Tatlilarstatli_id")
                        .HasColumnType("int");

                    b.Property<int?>("Urunlersurun_id")
                        .HasColumnType("int");

                    b.Property<string>("yorum_icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yorum_kullanici_id")
                        .HasColumnType("int");

                    b.Property<int>("yorum_puan")
                        .HasColumnType("int");

                    b.Property<DateTime>("yorum_tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("yorum_urun_id")
                        .HasColumnType("int");

                    b.HasKey("yorum_id");

                    b.HasIndex("Iceceklersicecek_id");

                    b.HasIndex("Kullanicilarskullanici_id");

                    b.HasIndex("Tatlilarstatli_id");

                    b.HasIndex("Urunlersurun_id");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.IcecekYorumlars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Iceceklers", "yorum_icecek")
                        .WithMany("icecek_yorumlari_s")
                        .HasForeignKey("yorum_icecekicecek_id");

                    b.Navigation("yorum_icecek");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Iceceklers", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.IcecekKategoris", "icecek_kategori")
                        .WithMany("Iceceklers")
                        .HasForeignKey("icecek_kategori_id");

                    b.Navigation("icecek_kategori");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.TatlilarYorumlars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Tatlilars", "yorum_tatli")
                        .WithMany("tatli_yorumlari_s")
                        .HasForeignKey("yorum_tatlitatli_id");

                    b.Navigation("yorum_tatli");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Tatlilars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.TatlilarKategoris", "tatli_kategori")
                        .WithMany("Tatlilars")
                        .HasForeignKey("tatli_kategori_id");

                    b.Navigation("tatli_kategori");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.UrunlerYorumlars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Urunlers", "yorum_urun")
                        .WithMany("urun_yorumlari_s")
                        .HasForeignKey("yorum_urunurun_id");

                    b.Navigation("yorum_urun");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Urunlers", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.UrunKategoris", "urun_kategori")
                        .WithMany("urunler")
                        .HasForeignKey("urun_kategori_id");

                    b.Navigation("urun_kategori");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Yorumlars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Iceceklers", null)
                        .WithMany("icecek_yorumlar")
                        .HasForeignKey("Iceceklersicecek_id");

                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Kullanicilars", null)
                        .WithMany("kullanici_yorumlar")
                        .HasForeignKey("Kullanicilarskullanici_id");

                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Tatlilars", null)
                        .WithMany("tatli_yorumlar")
                        .HasForeignKey("Tatlilarstatli_id");

                    b.HasOne("DrinkDiscovery_Admin_Revised.Models.Urunlers", null)
                        .WithMany("urun_yorumlar")
                        .HasForeignKey("Urunlersurun_id");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.IcecekKategoris", b =>
                {
                    b.Navigation("Iceceklers");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Iceceklers", b =>
                {
                    b.Navigation("icecek_yorumlar");

                    b.Navigation("icecek_yorumlari_s");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Kullanicilars", b =>
                {
                    b.Navigation("kullanici_yorumlar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.TatlilarKategoris", b =>
                {
                    b.Navigation("Tatlilars");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Tatlilars", b =>
                {
                    b.Navigation("tatli_yorumlar");

                    b.Navigation("tatli_yorumlari_s");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.UrunKategoris", b =>
                {
                    b.Navigation("urunler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin_Revised.Models.Urunlers", b =>
                {
                    b.Navigation("urun_yorumlar");

                    b.Navigation("urun_yorumlari_s");
                });
#pragma warning restore 612, 618
        }
    }
}
