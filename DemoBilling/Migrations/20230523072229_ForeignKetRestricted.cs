using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBilling.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKetRestricted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_customers_UserId",
                table: "bills");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseDetails_Products_ProductId",
                table: "purchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseDetails_bills_BillId",
                table: "purchaseDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_customers_UserId",
                table: "bills",
                column: "UserId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseDetails_Products_ProductId",
                table: "purchaseDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseDetails_bills_BillId",
                table: "purchaseDetails",
                column: "BillId",
                principalTable: "bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_customers_UserId",
                table: "bills");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseDetails_Products_ProductId",
                table: "purchaseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseDetails_bills_BillId",
                table: "purchaseDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_customers_UserId",
                table: "bills",
                column: "UserId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseDetails_Products_ProductId",
                table: "purchaseDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseDetails_bills_BillId",
                table: "purchaseDetails",
                column: "BillId",
                principalTable: "bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
