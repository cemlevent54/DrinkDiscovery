using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_like_dislike_feature_revised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcecekYorumBegenmes",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekYorumBegenmes", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_IcecekYorumBegenmes_IcecekYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "IcecekYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "TatliYorumBegenmes",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatliYorumBegenmes", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_TatliYorumBegenmes_TatlilarYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "TatlilarYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "UrunYorumBegenmes",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunYorumBegenmes", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_UrunYorumBegenmes_UrunlerYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "UrunlerYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcecekYorumBegenmes_begenme_yorumyorum_id",
                table: "IcecekYorumBegenmes",
                column: "begenme_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_TatliYorumBegenmes_begenme_yorumyorum_id",
                table: "TatliYorumBegenmes",
                column: "begenme_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_UrunYorumBegenmes_begenme_yorumyorum_id",
                table: "UrunYorumBegenmes",
                column: "begenme_yorumyorum_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcecekYorumBegenmes");

            migrationBuilder.DropTable(
                name: "TatliYorumBegenmes");

            migrationBuilder.DropTable(
                name: "UrunYorumBegenmes");
        }
    }
}
