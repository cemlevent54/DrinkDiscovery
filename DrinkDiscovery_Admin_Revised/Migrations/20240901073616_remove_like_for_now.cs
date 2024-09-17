using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class remove_like_for_now : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcecekCommentLikings");

            migrationBuilder.DropTable(
                name: "TatliCommentLikings");

            migrationBuilder.DropTable(
                name: "UrunCommentLikings");

            migrationBuilder.DropColumn(
                name: "yorum_begeni_sayisi",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begeni_sayisi",
                table: "TatlilarYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "TatlilarYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begeni_sayisi",
                table: "IcecekYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "IcecekYorumlars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yorum_begeni_sayisi",
                table: "UrunlerYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "UrunlerYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begeni_sayisi",
                table: "TatlilarYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "TatlilarYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begeni_sayisi",
                table: "IcecekYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "IcecekYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IcecekCommentLikings",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekCommentLikings", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_IcecekCommentLikings_IcecekYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "IcecekYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "TatliCommentLikings",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatliCommentLikings", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_TatliCommentLikings_TatlilarYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "TatlilarYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateTable(
                name: "UrunCommentLikings",
                columns: table => new
                {
                    begenme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    begenme_yorumyorum_id = table.Column<int>(type: "int", nullable: true),
                    begenme_durum = table.Column<bool>(type: "bit", nullable: false),
                    begenme_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    begenme_yorum_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunCommentLikings", x => x.begenme_id);
                    table.ForeignKey(
                        name: "FK_UrunCommentLikings_UrunlerYorumlars_begenme_yorumyorum_id",
                        column: x => x.begenme_yorumyorum_id,
                        principalTable: "UrunlerYorumlars",
                        principalColumn: "yorum_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcecekCommentLikings_begenme_yorumyorum_id",
                table: "IcecekCommentLikings",
                column: "begenme_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_TatliCommentLikings_begenme_yorumyorum_id",
                table: "TatliCommentLikings",
                column: "begenme_yorumyorum_id");

            migrationBuilder.CreateIndex(
                name: "IX_UrunCommentLikings_begenme_yorumyorum_id",
                table: "UrunCommentLikings",
                column: "begenme_yorumyorum_id");
        }
    }
}
