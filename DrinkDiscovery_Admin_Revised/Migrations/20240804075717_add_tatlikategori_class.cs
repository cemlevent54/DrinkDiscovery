using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_tatlikategori_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tatlilarstatli_id",
                table: "Yorumlar",
                type: "int",
                nullable: true);

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
                name: "Tatlilar",
                columns: table => new
                {
                    tatli_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tatli_ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_fiyat = table.Column<float>(type: "real", nullable: true),
                    tatli_puan = table.Column<float>(type: "real", nullable: true),
                    tatli_malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_yapilis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_kategori_id = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_Tatlilarstatli_id",
                table: "Yorumlar",
                column: "Tatlilarstatli_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tatlilar_tatli_kategori_id",
                table: "Tatlilar",
                column: "tatli_kategori_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Tatlilar_Tatlilarstatli_id",
                table: "Yorumlar",
                column: "Tatlilarstatli_id",
                principalTable: "Tatlilar",
                principalColumn: "tatli_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Tatlilar_Tatlilarstatli_id",
                table: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Tatlilar");

            migrationBuilder.DropTable(
                name: "TatlilarKategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Yorumlar_Tatlilarstatli_id",
                table: "Yorumlar");

            migrationBuilder.DropColumn(
                name: "Tatlilarstatli_id",
                table: "Yorumlar");
        }
    }
}
