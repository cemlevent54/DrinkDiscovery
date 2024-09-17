using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_comment_actions_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yorum_dislike_count",
                table: "UrunlerYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yorum_like_count",
                table: "UrunlerYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "yorum_like_state",
                table: "UrunlerYorumlars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "yorum_dislike_count",
                table: "TatlilarYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yorum_like_count",
                table: "TatlilarYorumlars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "yorum_like_state",
                table: "TatlilarYorumlars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserProductCommentActions",
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
                    table.PrimaryKey("PK_UserProductCommentActions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserSweetCommentActions",
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
                    table.PrimaryKey("PK_UserSweetCommentActions", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProductCommentActions");

            migrationBuilder.DropTable(
                name: "UserSweetCommentActions");

            migrationBuilder.DropColumn(
                name: "yorum_dislike_count",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_like_count",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_like_state",
                table: "UrunlerYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_dislike_count",
                table: "TatlilarYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_like_count",
                table: "TatlilarYorumlars");

            migrationBuilder.DropColumn(
                name: "yorum_like_state",
                table: "TatlilarYorumlars");
        }
    }
}
