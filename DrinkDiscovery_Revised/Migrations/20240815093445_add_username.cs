using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_username : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kullanici_fotograf",
                table: "AspNetUsers",
                newName: "KullaniciFotograf");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciUsername",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciUsername",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KullaniciFotograf",
                table: "AspNetUsers",
                newName: "kullanici_fotograf");
        }
    }
}
