using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinkDiscovery_Admin_Revised.Migrations
{
    /// <inheritdoc />
    public partial class add_user_id_to_payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_order_id_fk",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "order_id_fk",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "payment_user_id",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_order_id_fk",
                table: "Payment",
                column: "order_id_fk",
                principalTable: "Order",
                principalColumn: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_order_id_fk",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "payment_user_id",
                table: "Payment");

            migrationBuilder.AlterColumn<int>(
                name: "order_id_fk",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_order_id_fk",
                table: "Payment",
                column: "order_id_fk",
                principalTable: "Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
