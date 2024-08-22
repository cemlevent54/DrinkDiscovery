using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Revised.Migrations.DrinkDiscoveryAdmin
{
    /// <inheritdoc />
    public partial class change_comment_id_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_fotograf = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "IcecekKategoriler",
                columns: table => new
                {
                    icecek_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekKategoriler", x => x.icecek_kategori_id);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    kullanici_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullanici_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullanici_soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullanici_sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullanici_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullanici_telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kullanici_fotograf = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.kullanici_id);
                });

            migrationBuilder.CreateTable(
                name: "TatlilarKategoriler",
                columns: table => new
                {
                    tatli_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tatli_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatlilarKategoriler", x => x.tatli_kategori_id);
                });

            migrationBuilder.CreateTable(
                name: "UrunKategoriler",
                columns: table => new
                {
                    urun_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategoriler", x => x.urun_kategori_id);
                });

            migrationBuilder.CreateTable(
                name: "Icecekler",
                columns: table => new
                {
                    icecek_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_resim = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    icecek_fiyat = table.Column<float>(type: "real", nullable: false),
                    icecek_yapilis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_puan = table.Column<float>(type: "real", nullable: false),
                    icecek_kategori_id = table.Column<int>(type: "int", nullable: true),
                    beverage_cat_id = table.Column<int>(type: "int", nullable: false),
                    haftanin_icecegi = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecekler", x => x.icecek_id);
                    table.ForeignKey(
                        name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                        column: x => x.icecek_kategori_id,
                        principalTable: "IcecekKategoriler",
                        principalColumn: "icecek_kategori_id");
                });

            migrationBuilder.CreateTable(
                name: "Tatlilar",
                columns: table => new
                {
                    tatli_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tatli_ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_fiyat = table.Column<float>(type: "real", nullable: true),
                    tatli_puan = table.Column<float>(type: "real", nullable: true),
                    tatli_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_yapilis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_kategori_id = table.Column<int>(type: "int", nullable: true),
                    tatli_resim = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    display = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tatlilar", x => x.tatli_id);
                    table.ForeignKey(
                        name: "FK_Tatlilar_TatlilarKategoriler_tatli_kategori_id",
                        column: x => x.tatli_kategori_id,
                        principalTable: "TatlilarKategoriler",
                        principalColumn: "tatli_kategori_id");
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    urun_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_resim = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    urun_fiyat = table.Column<float>(type: "real", nullable: false),
                    urun_icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_puan = table.Column<float>(type: "real", nullable: false),
                    urun_kategori_id = table.Column<int>(type: "int", nullable: true),
                    product_cat_id = table.Column<int>(type: "int", nullable: false),
                    display_slider = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.urun_id);
                    table.ForeignKey(
                        name: "FK_Urunler_UrunKategoriler_urun_kategori_id",
                        column: x => x.urun_kategori_id,
                        principalTable: "UrunKategoriler",
                        principalColumn: "urun_kategori_id");
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_puan = table.Column<int>(type: "int", nullable: true),
                    yorum_tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    yorum_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_urun_id = table.Column<int>(type: "int", nullable: true),
                    Iceceklersicecek_id = table.Column<int>(type: "int", nullable: true),
                    Kullanicilarskullanici_id = table.Column<int>(type: "int", nullable: true),
                    Urunlersurun_id = table.Column<int>(type: "int", nullable: true),
                    Tatlilarstatli_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Icecekler_Iceceklersicecek_id",
                        column: x => x.Iceceklersicecek_id,
                        principalTable: "Icecekler",
                        principalColumn: "icecek_id");
                    table.ForeignKey(
                        name: "FK_Yorumlar_Kullanicilar_Kullanicilarskullanici_id",
                        column: x => x.Kullanicilarskullanici_id,
                        principalTable: "Kullanicilar",
                        principalColumn: "kullanici_id");
                    table.ForeignKey(
                        name: "FK_Yorumlar_Tatlilar_Tatlilarstatli_id",
                        column: x => x.Tatlilarstatli_id,
                        principalTable: "Tatlilar",
                        principalColumn: "tatli_id");
                    table.ForeignKey(
                        name: "FK_Yorumlar_Urunler_Urunlersurun_id",
                        column: x => x.Urunlersurun_id,
                        principalTable: "Urunler",
                        principalColumn: "urun_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tatlilar_tatli_kategori_id",
                table: "Tatlilar",
                column: "tatli_kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_urun_kategori_id",
                table: "Urunler",
                column: "urun_kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Iceceklersicecek_id",
                table: "Yorumlar",
                column: "Iceceklersicecek_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Kullanicilarskullanici_id",
                table: "Yorumlar",
                column: "Kullanicilarskullanici_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Tatlilarstatli_id",
                table: "Yorumlar",
                column: "Tatlilarstatli_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Urunlersurun_id",
                table: "Yorumlar",
                column: "Urunlersurun_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Icecekler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Tatlilar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "IcecekKategoriler");

            migrationBuilder.DropTable(
                name: "TatlilarKategoriler");

            migrationBuilder.DropTable(
                name: "UrunKategoriler");
        }
    }
}
