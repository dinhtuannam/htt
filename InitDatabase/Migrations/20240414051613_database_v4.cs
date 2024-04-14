using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitDatabase.Migrations
{
    /// <inheritdoc />
    public partial class database_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imagePath",
                table: "tb_menu_item",
                newName: "image_path");

            migrationBuilder.RenameColumn(
                name: "customerCode",
                table: "tb_log_table",
                newName: "customer_code");

            migrationBuilder.RenameColumn(
                name: "expiredTime",
                table: "tb_discounts",
                newName: "expired_time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image_path",
                table: "tb_menu_item",
                newName: "imagePath");

            migrationBuilder.RenameColumn(
                name: "customer_code",
                table: "tb_log_table",
                newName: "customerCode");

            migrationBuilder.RenameColumn(
                name: "expired_time",
                table: "tb_discounts",
                newName: "expiredTime");
        }
    }
}
