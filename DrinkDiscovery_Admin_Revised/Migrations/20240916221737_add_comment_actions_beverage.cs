using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_comment_actions_beverage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBeverageCommentActions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment_id = table.Column<int>(type: "int", nullable: true),
                    is_liked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBeverageCommentActions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBeverageCommentActions");
        }
    }
}
