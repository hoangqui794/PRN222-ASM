using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyewearShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameRequestIdAndRefundId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requestID",
                table: "RefundTaiND",
                newName: "requestIDTaiND");

            migrationBuilder.RenameColumn(
                name: "refundID",
                table: "RefundTaiND",
                newName: "refundIDTaiND");

            migrationBuilder.RenameIndex(
                name: "IX_RefundTaiND_requestID",
                table: "RefundTaiND",
                newName: "IX_RefundTaiND_requestIDTaiND");

            migrationBuilder.RenameColumn(
                name: "requestID",
                table: "AfterSalesTaiND",
                newName: "requestIDTaiND");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requestIDTaiND",
                table: "RefundTaiND",
                newName: "requestID");

            migrationBuilder.RenameColumn(
                name: "refundIDTaiND",
                table: "RefundTaiND",
                newName: "refundID");

            migrationBuilder.RenameIndex(
                name: "IX_RefundTaiND_requestIDTaiND",
                table: "RefundTaiND",
                newName: "IX_RefundTaiND_requestID");

            migrationBuilder.RenameColumn(
                name: "requestIDTaiND",
                table: "AfterSalesTaiND",
                newName: "requestID");
        }
    }
}
