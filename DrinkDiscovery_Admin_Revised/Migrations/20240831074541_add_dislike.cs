using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_dislike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "UrunlerYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "TatlilarYorumlars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "yorum_begenmeme_sayisi",
                table: "IcecekYorumlars",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "TatlilarYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_begenmeme_sayisi",
                table: "IcecekYorumlars");
        }
    }
}
