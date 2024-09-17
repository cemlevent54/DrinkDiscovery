using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class like_dislike_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yorum_dislike_count",
                table: "IcecekYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yorum_like_count",
                table: "IcecekYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yorum_dislike_count",
                table: "IcecekYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_like_count",
                table: "IcecekYorumlars");
        }
    }
}
