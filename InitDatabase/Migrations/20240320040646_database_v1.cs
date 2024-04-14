using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitDatabase.Migrations
{
    /// <inheritdoc />
    public partial class database_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_recipes_tb_ingredients_ingredientid",
                table: "tb_recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_recipes_tb_menu_item_menuid",
                table: "tb_recipes");

            migrationBuilder.DropIndex(
                name: "IX_tb_recipes_ingredientid",
                table: "tb_recipes");

            migrationBuilder.DropIndex(
                name: "IX_tb_recipes_menuid",
                table: "tb_recipes");

            migrationBuilder.DropColumn(
                name: "ingredientid",
                table: "tb_recipes");

            migrationBuilder.DropColumn(
                name: "menuid",
                table: "tb_recipes");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "tb_recipes");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "tb_recipes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "recipesid",
                table: "tb_menu_item",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_detail_recipe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    unit = table.Column<string>(type: "text", nullable: false),
                    ingredientid = table.Column<long>(type: "bigint", nullable: true),
                    recipeid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_detail_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_detail_recipe_tb_ingredients_ingredientid",
                        column: x => x.ingredientid,
                        principalTable: "tb_ingredients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_detail_recipe_tb_recipes_recipeid",
                        column: x => x.recipeid,
                        principalTable: "tb_recipes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_menu_item_recipesid",
                table: "tb_menu_item",
                column: "recipesid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_recipe_ingredientid",
                table: "tb_detail_recipe",
                column: "ingredientid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_recipe_recipeid",
                table: "tb_detail_recipe",
                column: "recipeid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_menu_item_tb_recipes_recipesid",
                table: "tb_menu_item",
                column: "recipesid",
                principalTable: "tb_recipes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_menu_item_tb_recipes_recipesid",
                table: "tb_menu_item");

            migrationBuilder.DropTable(
                name: "tb_detail_recipe");

            migrationBuilder.DropIndex(
                name: "IX_tb_menu_item_recipesid",
                table: "tb_menu_item");

            migrationBuilder.DropColumn(
                name: "name",
                table: "tb_recipes");

            migrationBuilder.DropColumn(
                name: "recipesid",
                table: "tb_menu_item");

            migrationBuilder.AddColumn<long>(
                name: "ingredientid",
                table: "tb_recipes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "menuid",
                table: "tb_recipes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                table: "tb_recipes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_tb_recipes_ingredientid",
                table: "tb_recipes",
                column: "ingredientid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recipes_menuid",
                table: "tb_recipes",
                column: "menuid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_recipes_tb_ingredients_ingredientid",
                table: "tb_recipes",
                column: "ingredientid",
                principalTable: "tb_ingredients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_recipes_tb_menu_item_menuid",
                table: "tb_recipes",
                column: "menuid",
                principalTable: "tb_menu_item",
                principalColumn: "id");
        }
    }
}
