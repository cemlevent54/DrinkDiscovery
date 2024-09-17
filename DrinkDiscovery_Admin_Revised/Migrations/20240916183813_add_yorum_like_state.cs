using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_yorum_like_state : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "yorum_like_state",
                table: "IcecekYorumlars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yorum_like_state",
                table: "IcecekYorumlars");
        }
    }
}
