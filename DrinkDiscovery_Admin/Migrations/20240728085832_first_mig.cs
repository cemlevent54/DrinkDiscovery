using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class first_mig : Migration
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
                name: "Icecekler",
                columns: table => new
                {
                    icecek_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_resim = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    icecek_fiyat = table.Column<int>(type: "int", nullable: false),
                    icecek_icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icecek_puan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icecekler", x => x.icecek_id);
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
                name: "Urunler",
                columns: table => new
                {
                    urun_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_resim = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    urun_fiyat = table.Column<int>(type: "int", nullable: false),
                    urun_icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urun_puan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.urun_id);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yorum_puan = table.Column<int>(type: "int", nullable: false),
                    yorum_tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    yorum_kullanici_id = table.Column<int>(type: "int", nullable: false),
                    yorum_urun_id = table.Column<int>(type: "int", nullable: false),
                    Iceceklersicecek_id = table.Column<int>(type: "int", nullable: true),
                    Kullanicilarskullanici_id = table.Column<int>(type: "int", nullable: true),
                    Urunlersurun_id = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Yorumlar_Urunler_Urunlersurun_id",
                        column: x => x.Urunlersurun_id,
                        principalTable: "Urunler",
                        principalColumn: "urun_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Iceceklersicecek_id",
                table: "Yorumlar",
                column: "Iceceklersicecek_id");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Kullanicilarskullanici_id",
                table: "Yorumlar",
                column: "Kullanicilarskullanici_id");

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
                name: "Urunler");
        }
    }
}
