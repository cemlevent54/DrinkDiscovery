using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class kat_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "urun_kategori_id",
                table: "Urunler",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_urun_kategori_id",
                table: "Urunler",
                column: "urun_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunKategoriler_urun_kategori_id",
                table: "Urunler",
                column: "urun_kategori_id",
                principalTable: "UrunKategoriler",
                principalColumn: "urun_kategori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunKategoriler_urun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropTable(
                name: "UrunKategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_urun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "urun_kategori_id",
                table: "Urunler");
        }
    }
}
