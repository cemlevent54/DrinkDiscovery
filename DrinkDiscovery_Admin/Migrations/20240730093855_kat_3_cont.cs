using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class kat_3_cont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunKategoriler_urun_kategori_id1",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_urun_kategori_id1",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "urun_kategori_id1",
                table: "Urunler");

            migrationBuilder.DropColumn(
                name: "icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.AlterColumn<int>(
                name: "urun_kategori_id",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "icecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_urun_kategori_id",
                table: "Urunler",
                column: "urun_kategori_id");

            migrationBuilder.CreateIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id",
                principalTable: "IcecekKategoriler",
                principalColumn: "icecek_kategori_id");

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
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_UrunKategoriler_urun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_urun_kategori_id",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.AlterColumn<int>(
                name: "urun_kategori_id",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "urun_kategori_id1",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "icecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "icecek_kategori_id1",
                table: "Icecekler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_urun_kategori_id1",
                table: "Urunler",
                column: "urun_kategori_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Icecekler_icecek_kategori_id1",
                table: "Icecekler",
                column: "icecek_kategori_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id1",
                table: "Icecekler",
                column: "icecek_kategori_id1",
                principalTable: "IcecekKategoriler",
                principalColumn: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_UrunKategoriler_urun_kategori_id1",
                table: "Urunler",
                column: "urun_kategori_id1",
                principalTable: "UrunKategoriler",
                principalColumn: "urun_kategori_id");
        }
    }
}
