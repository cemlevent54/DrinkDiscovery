using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class kategoriduzeltme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisicecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.RenameColumn(
                name: "icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                newName: "icecek_kategorisdrink_kategori_id");

            migrationBuilder.RenameIndex(
                name: "IX_Icecekler_icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                newName: "IX_Icecekler_icecek_kategorisdrink_kategori_id");

            migrationBuilder.RenameColumn(
                name: "icecek_kategori_id",
                table: "IcecekKategori",
                newName: "drink_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisdrink_kategori_id",
                table: "Icecekler",
                column: "icecek_kategorisdrink_kategori_id",
                principalTable: "IcecekKategori",
                principalColumn: "drink_kategori_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisdrink_kategori_id",
                table: "Icecekler");

            migrationBuilder.RenameColumn(
                name: "icecek_kategorisdrink_kategori_id",
                table: "Icecekler",
                newName: "icecek_kategorisicecek_kategori_id");

            migrationBuilder.RenameIndex(
                name: "IX_Icecekler_icecek_kategorisdrink_kategori_id",
                table: "Icecekler",
                newName: "IX_Icecekler_icecek_kategorisicecek_kategori_id");

            migrationBuilder.RenameColumn(
                name: "drink_kategori_id",
                table: "IcecekKategori",
                newName: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategori_icecek_kategorisicecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategorisicecek_kategori_id",
                principalTable: "IcecekKategori",
                principalColumn: "icecek_kategori_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
