using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCore.Microservices.Services.CouponApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCouponPKName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coupon",
                newName: "CouponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Coupon",
                newName: "Id");
        }
    }
}
