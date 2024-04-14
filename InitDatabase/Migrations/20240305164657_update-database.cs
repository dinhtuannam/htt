using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitDatabase.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_actions",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_actions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_discounts",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    minimum = table.Column<int>(type: "integer", nullable: false),
                    remaining = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    expiredTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_discounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ingredients",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    unit = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ingredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_menu_item_status",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_menu_item_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_table_status",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_table_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_invoices",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    discount_price = table.Column<double>(type: "double precision", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_invoices_tb_discounts_discountid",
                        column: x => x.discountid,
                        principalTable: "tb_discounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_menu_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    ingredients = table.Column<string>(type: "text", nullable: false),
                    imagePath = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    profit = table.Column<double>(type: "double precision", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    statusid = table.Column<string>(type: "text", nullable: true),
                    categoryid = table.Column<long>(type: "bigint", nullable: true),
                    createTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_menu_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_menu_item_tb_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "tb_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_menu_item_tb_menu_item_status_statusid",
                        column: x => x.statusid,
                        principalTable: "tb_menu_item_status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    roleid = table.Column<string>(type: "text", nullable: true),
                    createTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_users_tb_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "tb_roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_tables",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    des = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    customer_code = table.Column<string>(type: "text", nullable: false),
                    statusid = table.Column<string>(type: "text", nullable: true),
                    createTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tables", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tables_tb_table_status_statusid",
                        column: x => x.statusid,
                        principalTable: "tb_table_status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_recipes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    menuid = table.Column<long>(type: "bigint", nullable: true),
                    ingredientid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_recipes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_recipes_tb_ingredients_ingredientid",
                        column: x => x.ingredientid,
                        principalTable: "tb_ingredients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_recipes_tb_menu_item_menuid",
                        column: x => x.menuid,
                        principalTable: "tb_menu_item",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_log_table",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    note = table.Column<string>(type: "text", nullable: false),
                    customerCode = table.Column<string>(type: "text", nullable: false),
                    tableid = table.Column<long>(type: "bigint", nullable: true),
                    actionid = table.Column<string>(type: "text", nullable: true),
                    time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_log_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_log_table_tb_actions_actionid",
                        column: x => x.actionid,
                        principalTable: "tb_actions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_log_table_tb_tables_tableid",
                        column: x => x.tableid,
                        principalTable: "tb_tables",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_code = table.Column<string>(type: "text", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    staffid = table.Column<long>(type: "bigint", nullable: true),
                    tableid = table.Column<long>(type: "bigint", nullable: true),
                    createTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_orders_tb_tables_tableid",
                        column: x => x.tableid,
                        principalTable: "tb_tables",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_orders_tb_users_staffid",
                        column: x => x.staffid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_detail_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    profit = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false),
                    itemid = table.Column<long>(type: "bigint", nullable: true),
                    orderid = table.Column<long>(type: "bigint", nullable: true),
                    invoiceid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_detail_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_detail_order_tb_invoices_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "tb_invoices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_detail_order_tb_menu_item_itemid",
                        column: x => x.itemid,
                        principalTable: "tb_menu_item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_detail_order_tb_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "tb_orders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_order_invoiceid",
                table: "tb_detail_order",
                column: "invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_order_itemid",
                table: "tb_detail_order",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_order_orderid",
                table: "tb_detail_order",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_invoices_discountid",
                table: "tb_invoices",
                column: "discountid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_log_table_actionid",
                table: "tb_log_table",
                column: "actionid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_log_table_tableid",
                table: "tb_log_table",
                column: "tableid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_menu_item_categoryid",
                table: "tb_menu_item",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_menu_item_statusid",
                table: "tb_menu_item",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_staffid",
                table: "tb_orders",
                column: "staffid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_orders_tableid",
                table: "tb_orders",
                column: "tableid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recipes_ingredientid",
                table: "tb_recipes",
                column: "ingredientid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recipes_menuid",
                table: "tb_recipes",
                column: "menuid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tables_statusid",
                table: "tb_tables",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_users_roleid",
                table: "tb_users",
                column: "roleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_detail_order");

            migrationBuilder.DropTable(
                name: "tb_log_table");

            migrationBuilder.DropTable(
                name: "tb_recipes");

            migrationBuilder.DropTable(
                name: "tb_invoices");

            migrationBuilder.DropTable(
                name: "tb_orders");

            migrationBuilder.DropTable(
                name: "tb_actions");

            migrationBuilder.DropTable(
                name: "tb_ingredients");

            migrationBuilder.DropTable(
                name: "tb_menu_item");

            migrationBuilder.DropTable(
                name: "tb_discounts");

            migrationBuilder.DropTable(
                name: "tb_tables");

            migrationBuilder.DropTable(
                name: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_categories");

            migrationBuilder.DropTable(
                name: "tb_menu_item_status");

            migrationBuilder.DropTable(
                name: "tb_table_status");

            migrationBuilder.DropTable(
                name: "tb_roles");
        }
    }
}
