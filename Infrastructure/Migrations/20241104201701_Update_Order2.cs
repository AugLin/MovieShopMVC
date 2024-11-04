using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Order2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_OrderId",
                table: "Order_Detail");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_OrderId",
                table: "Order_Detail",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Detail_OrderId",
                table: "Order_Detail");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Detail_OrderId",
                table: "Order_Detail",
                column: "OrderId",
                unique: true);
        }
    }
}
