using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBProjekat2025.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseAfterShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Pice_PiceId",
                table: "OrdersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersItems",
                table: "OrdersItems");

            migrationBuilder.RenameTable(
                name: "OrdersItems",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_PiceId",
                table: "OrderItems",
                newName: "IX_OrderItems_PiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AlterColumn<double>(
                name: "Cena",
                table: "OrderItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Pice_PiceId",
                table: "OrderItems",
                column: "PiceId",
                principalTable: "Pice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Pice_PiceId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrdersItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_PiceId",
                table: "OrdersItems",
                newName: "IX_OrdersItems_PiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrdersItems",
                newName: "IX_OrdersItems_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "Cena",
                table: "OrdersItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersItems",
                table: "OrdersItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                table: "OrdersItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Pice_PiceId",
                table: "OrdersItems",
                column: "PiceId",
                principalTable: "Pice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
