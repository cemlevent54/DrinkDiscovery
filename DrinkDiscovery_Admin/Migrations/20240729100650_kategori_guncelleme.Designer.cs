﻿// <auto-generated />
using System;
using DrinkDiscovery_Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240729100650_kategori_guncelleme")]
    partial class kategori_guncelleme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Adminlers", b =>
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

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.IcecekKategori", b =>
                {
                    b.Property<int>("icecek_kategori_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("icecek_kategori_id"));

                    b.Property<string>("icecek_kategori_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("icecek_kategori_id");

                    b.ToTable("IcecekKategori");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Iceceklers", b =>
                {
                    b.Property<int>("icecek_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("icecek_id"));

                    b.Property<string>("icecek_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("icecek_fiyat")
                        .HasColumnType("int");

                    b.Property<string>("icecek_icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("icecek_kategori_id")
                        .HasColumnType("int");

                    b.Property<int>("icecek_kategorisicecek_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("icecek_malzemeler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icecek_puan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("icecek_resim")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("icecek_id");

                    b.HasIndex("icecek_kategorisicecek_kategori_id");

                    b.ToTable("Icecekler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Kullanicilars", b =>
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

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.UrunKategori", b =>
                {
                    b.Property<int>("urun_kategori_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urun_kategori_id"));

                    b.Property<string>("urun_kategori_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("urun_kategori_id");

                    b.ToTable("UrunKategori");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Urunlers", b =>
                {
                    b.Property<int>("urun_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urun_id"));

                    b.Property<int>("UrunKategorisurun_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("urun_ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("urun_fiyat")
                        .HasColumnType("int");

                    b.Property<string>("urun_icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("urun_kategori_id")
                        .HasColumnType("int");

                    b.Property<string>("urun_malzemeler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("urun_puan")
                        .HasColumnType("int");

                    b.Property<byte[]>("urun_resim")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("urun_id");

                    b.HasIndex("UrunKategorisurun_kategori_id");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Yorumlars", b =>
                {
                    b.Property<int>("yorum_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yorum_id"));

                    b.Property<int?>("Iceceklersicecek_id")
                        .HasColumnType("int");

                    b.Property<int?>("Kullanicilarskullanici_id")
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

                    b.HasIndex("Urunlersurun_id");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Iceceklers", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin.Models.IcecekKategori", "icecek_kategoris")
                        .WithMany("Iceceklers")
                        .HasForeignKey("icecek_kategorisicecek_kategori_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("icecek_kategoris");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Urunlers", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin.Models.UrunKategori", "UrunKategoris")
                        .WithMany("Urunlers")
                        .HasForeignKey("UrunKategorisurun_kategori_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UrunKategoris");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Yorumlars", b =>
                {
                    b.HasOne("DrinkDiscovery_Admin.Models.Iceceklers", null)
                        .WithMany("icecek_yorumlar")
                        .HasForeignKey("Iceceklersicecek_id");

                    b.HasOne("DrinkDiscovery_Admin.Models.Kullanicilars", null)
                        .WithMany("kullanici_yorumlar")
                        .HasForeignKey("Kullanicilarskullanici_id");

                    b.HasOne("DrinkDiscovery_Admin.Models.Urunlers", null)
                        .WithMany("urun_yorumlar")
                        .HasForeignKey("Urunlersurun_id");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.IcecekKategori", b =>
                {
                    b.Navigation("Iceceklers");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Iceceklers", b =>
                {
                    b.Navigation("icecek_yorumlar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Kullanicilars", b =>
                {
                    b.Navigation("kullanici_yorumlar");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.UrunKategori", b =>
                {
                    b.Navigation("Urunlers");
                });

            modelBuilder.Entity("DrinkDiscovery_Admin.Models.Urunlers", b =>
                {
                    b.Navigation("urun_yorumlar");
                });
#pragma warning restore 612, 618
        }
    }
}
