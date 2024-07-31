using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "icecek_kategori_id1",
                table: "Icecekler");

            migrationBuilder.AlterColumn<int>(
                name: "icecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "beverage_cat_id",
                table: "Icecekler",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "beverage_cat_id",
                table: "Icecekler");

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
                name: "IX_Icecekler_icecek_kategori_id1",
                table: "Icecekler",
                column: "icecek_kategori_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoriler_icecek_kategori_id1",
                table: "Icecekler",
                column: "icecek_kategori_id1",
                principalTable: "IcecekKategoriler",
                principalColumn: "icecek_kategori_id");
        }
    }
}
