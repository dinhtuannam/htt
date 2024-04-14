using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InitDatabase.Migrations
{
    /// <inheritdoc />
    public partial class database_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_supplier",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    isdeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_import_bill",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    import_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: true),
                    supplierid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_import_bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_import_bill_tb_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "tb_supplier",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_import_bill_tb_users_userid",
                        column: x => x.userid,
                        principalTable: "tb_users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_detail_import_bill",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    total = table.Column<double>(type: "double precision", nullable: false),
                    billid = table.Column<long>(type: "bigint", nullable: true),
                    ingredientid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_detail_import_bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_detail_import_bill_tb_import_bill_billid",
                        column: x => x.billid,
                        principalTable: "tb_import_bill",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_detail_import_bill_tb_ingredients_ingredientid",
                        column: x => x.ingredientid,
                        principalTable: "tb_ingredients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_import_bill_billid",
                table: "tb_detail_import_bill",
                column: "billid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_detail_import_bill_ingredientid",
                table: "tb_detail_import_bill",
                column: "ingredientid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_import_bill_supplierid",
                table: "tb_import_bill",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_import_bill_userid",
                table: "tb_import_bill",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_detail_import_bill");

            migrationBuilder.DropTable(
                name: "tb_import_bill");

            migrationBuilder.DropTable(
                name: "tb_supplier");
        }
    }
}
