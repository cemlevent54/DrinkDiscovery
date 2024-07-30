using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class kat_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "icecek_kategori_id",
                table: "Icecekler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IcecekKategoris",
                columns: table => new
                {
                    icecek_kategori_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_kategori_ad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekKategoris", x => x.icecek_kategori_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Icecekler_IcecekKategoris_icecek_kategori_id",
                table: "Icecekler",
                column: "icecek_kategori_id",
                principalTable: "IcecekKategoris",
                principalColumn: "icecek_kategori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Icecekler_IcecekKategoris_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropTable(
                name: "IcecekKategoris");

            migrationBuilder.DropIndex(
                name: "IX_Icecekler_icecek_kategori_id",
                table: "Icecekler");

            migrationBuilder.DropColumn(
                name: "icecek_kategori_id",
                table: "Icecekler");
        }
    }
}
