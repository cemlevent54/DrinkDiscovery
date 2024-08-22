using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_icecek_yorumlar_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcecekYorumlars",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_puan = table.Column<int>(type: "int", nullable: true),
                    yorum_tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    yorum_kullanici_id = table.Column<int>(type: "int", nullable: true),
                    yorum_onay = table.Column<bool>(type: "bit", nullable: true),
                    yorum_icecekicecek_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcecekYorumlars", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK_IcecekYorumlars_Icecekler_yorum_icecekicecek_id",
                        column: x => x.yorum_icecekicecek_id,
                        principalTable: "Icecekler",
                        principalColumn: "icecek_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcecekYorumlars_yorum_icecekicecek_id",
                table: "IcecekYorumlars",
                column: "yorum_icecekicecek_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcecekYorumlars");
        }
    }
}
