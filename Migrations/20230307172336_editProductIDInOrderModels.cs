using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMC.Migrations
{
    public partial class editProductIDInOrderModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Product_ProductId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductId",
                table: "orders",
                newName: "IX_orders_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Product_ProductID",
                table: "orders",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Product_ProductID",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductID",
                table: "orders",
                newName: "IX_orders_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Product_ProductId",
                table: "orders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
