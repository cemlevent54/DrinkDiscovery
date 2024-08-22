using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_other_classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "yorum_kullanici_id",
                table: "IcecekYorumlars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TatlilarYorumlars",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_puan = table.Column<int>(type: "int", nullable: true),
                    yorum_tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    yorum_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_onay = table.Column<bool>(type: "bit", nullable: true),
                    yorum_tatlitatli_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatlilarYorumlars", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK_TatlilarYorumlars_Tatlilar_yorum_tatlitatli_id",
                        column: x => x.yorum_tatlitatli_id,
                        principalTable: "Tatlilar",
                        principalColumn: "tatli_id");
                });

            migrationBuilder.CreateTable(
                name: "UrunlerYorumlars",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_puan = table.Column<int>(type: "int", nullable: true),
                    yorum_tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    yorum_kullanici_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yorum_onay = table.Column<bool>(type: "bit", nullable: true),
                    yorum_urunurun_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunlerYorumlars", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK_UrunlerYorumlars_Urunler_yorum_urunurun_id",
                        column: x => x.yorum_urunurun_id,
                        principalTable: "Urunler",
                        principalColumn: "urun_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TatlilarYorumlars_yorum_tatlitatli_id",
                table: "TatlilarYorumlars",
                column: "yorum_tatlitatli_id");

            migrationBuilder.CreateIndex(
                name: "IX_UrunlerYorumlars_yorum_urunurun_id",
                table: "UrunlerYorumlars",
                column: "yorum_urunurun_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TatlilarYorumlars");

            migrationBuilder.DropTable(
                name: "UrunlerYorumlars");

            migrationBuilder.AlterColumn<int>(
                name: "yorum_kullanici_id",
                table: "IcecekYorumlars",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
