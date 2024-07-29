using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin.Migrations
{
    /// <inheritdoc />
    public partial class update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "icecek_kategori_id",
                table: "Icecekler",
                newName: "kategori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kategori_id",
                table: "Icecekler",
                newName: "icecek_kategori_id");
        }
    }
}
