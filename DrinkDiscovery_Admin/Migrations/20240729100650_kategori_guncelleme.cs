using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class kategori_guncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrunKategorisurun_kategori_id",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "urun_kategori_id",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "icecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IcecekKategori",
                columns: table => new
                {
                    icecek_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekKategori", x => x.icecek_kategori_id);
                });

            migrationBuilder.CreateTable(
                name: "UrunKategori",
                columns: table => new
                {
                    urun_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunKategori", x => x.urun_kategori_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_UrunKategorisurun_kategori_id",
                table: "Urunler",
                column: "UrunKategorisurun_kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Icecekler_icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategorisicecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategorisicecek_kategori_id",
                principalTable: "IcecekKategori",
                principalColumn: "icecek_kategori_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunKategori_UrunKategorisurun_kategori_id",
                table: "Urunler",
                column: "UrunKategorisurun_kategori_id",
                principalTable: "UrunKategori",
                principalColumn: "urun_kategori_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisicecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunKategori_UrunKategorisurun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropTable(
                name: "IcecekKategori");

            migrationBuilder.DropTable(
                name: "UrunKategori");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_UrunKategorisurun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategorisicecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "UrunKategorisurun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "urun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "icecek_kategorisicecek_kategori_id",
                table: "Icecekler");
        }
    }
}
