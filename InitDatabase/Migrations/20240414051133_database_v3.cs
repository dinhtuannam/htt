using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InitDatabase.Migrations
{
    /// <inheritdoc />
    public partial class database_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updateTime",
                table: "tb_users",
                newName: "update_time");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "tb_users",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "updateTime",
                table: "tb_tables",
                newName: "update_time");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "tb_tables",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "updateTime",
                table: "tb_orders",
                newName: "update_time");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "tb_orders",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "updateTime",
                table: "tb_menu_item",
                newName: "update_time");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "tb_menu_item",
                newName: "create_time");

            migrationBuilder.RenameColumn(
                name: "updateTime",
                table: "tb_discounts",
                newName: "update_time");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "tb_discounts",
                newName: "create_time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "tb_users",
                newName: "updateTime");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "tb_users",
                newName: "createTime");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "tb_tables",
                newName: "updateTime");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "tb_tables",
                newName: "createTime");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "tb_orders",
                newName: "updateTime");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "tb_orders",
                newName: "createTime");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "tb_menu_item",
                newName: "updateTime");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "tb_menu_item",
                newName: "createTime");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "tb_discounts",
                newName: "updateTime");

            migrationBuilder.RenameColumn(
                name: "create_time",
                table: "tb_discounts",
                newName: "createTime");
        }
    }
}
