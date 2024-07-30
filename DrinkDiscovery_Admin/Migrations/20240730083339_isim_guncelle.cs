using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class isim_guncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoris_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IcecekKategoris",
                table: "IcecekKategoris");

            migrationBuilder.RenameTable(
                name: "IcecekKategoris",
                newName: "IcecekKategoriler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IcecekKategoriler",
                table: "IcecekKategoriler",
                column: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id",
                principalTable: "IcecekKategoriler",
                principalColumn: "icecek_kategori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IcecekKategoriler",
                table: "IcecekKategoriler");

            migrationBuilder.RenameTable(
                name: "IcecekKategoriler",
                newName: "IcecekKategoris");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IcecekKategoris",
                table: "IcecekKategoris",
                column: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoris_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id",
                principalTable: "IcecekKategoris",
                principalColumn: "icecek_kategori_id");
        }
    }
}
