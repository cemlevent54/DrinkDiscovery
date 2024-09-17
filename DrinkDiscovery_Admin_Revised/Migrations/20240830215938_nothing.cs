using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class nothing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcecekYorumBegenme");

            migrationBuilder.DropTable(
                name: "TatliYorumBegenme");

            migrationBuilder.DropTable(
                name: "UrunYorumBegenme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcecekYorumBegenme",
                columns: table => new
                {
                    icecek_begeni_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    icecek_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    icecek_begeni_durum = table.Column<bool>(type: "bit", nullable: false),
                    icecek_begeni_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icecek_begeni_yorum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekYorumBegenme", x => x.icecek_begeni_id);
                    table.ForeignKey(
                        name: "FK_IcecekYorumBegenme_IcecekYorumlars_icecek_yorumyorum_id",
                        column: x => x.icecek_yorumyorum_id,
                        principalTable: "IcecekYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "TatliYorumBegenme",
                columns: table => new
                {
                    tatli_begeni_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tatli_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    tatli_begeni_durum = table.Column<bool>(type: "bit", nullable: false),
                    tatli_begeni_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tatli_begeni_yorum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatliYorumBegenme", x => x.tatli_begeni_id);
                    table.ForeignKey(
                        name: "FK_TatliYorumBegenme_TatlilarYorumlars_tatli_yorumyorum_id",
                        column: x => x.tatli_yorumyorum_id,
                        principalTable: "TatlilarYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "UrunYorumBegenme",
                columns: table => new
                {
                    urun_begeni_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    Urunlersurun_id = table.Column<int>(type: "int", nullable: true),
                    urun_begeni_durum = table.Column<bool>(type: "bit", nullable: false),
                    urun_begeni_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urun_begeni_yorum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunYorumBegenme", x => x.urun_begeni_id);
                    table.ForeignKey(
                        name: "FK_UrunYorumBegenme_UrunlerYorumlars_urun_yorumyorum_id",
                        column: x => x.urun_yorumyorum_id,
                        principalTable: "UrunlerYorumlars",
                        principalColumn: "yorum_id");
                    table.ForeignKey(
                        name: "FK_UrunYorumBegenme_Urunler_Urunlersurun_id",
                        column: x => x.Urunlersurun_id,
                        principalTable: "Urunler",
                        principalColumn: "urun_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcecekYorumBegenme_icecek_yorumyorum_id",
                table: "IcecekYorumBegenme",
                column: "icecek_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_TatliYorumBegenme_tatli_yorumyorum_id",
                table: "TatliYorumBegenme",
                column: "tatli_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYorumBegenme_urun_yorumyorum_id",
                table: "UrunYorumBegenme",
                column: "urun_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYorumBegenme_Urunlersurun_id",
                table: "UrunYorumBegenme",
                column: "Urunlersurun_id");
        }
    }
}
