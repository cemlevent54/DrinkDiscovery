using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_payment_update_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "order_shopping_cart_status",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    payment_amount = table.Column<float>(type: "real", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_confirmation = table.Column<bool>(type: "bit", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_cart_holder_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_card_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_card_expiry_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_card_cvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_id_fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Payment_Order_order_id_fk",
                        column: x => x.order_id_fk,
                        principalTable: "Order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_order_id_fk",
                table: "Payment",
                column: "order_id_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropColumn(
                name: "order_shopping_cart_status",
                table: "Order");
        }
    }
}
