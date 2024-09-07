using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Of_Api.Migrations
{
    /// <inheritdoc />
    public partial class Firest_interview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitNo);
                });

            migrationBuilder.CreateTable(
                name: "invoiceDetails",
                columns: table => new
                {
                    lineNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNo = table.Column<int>(type: "int", nullable: false),
                    UnitNo1 = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoiceDetails", x => x.lineNo);
                    table.ForeignKey(
                        name: "FK_invoiceDetails_Units_UnitNo1",
                        column: x => x.UnitNo1,
                        principalTable: "Units",
                        principalColumn: "UnitNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetails_UnitNo1",
                table: "invoiceDetails",
                column: "UnitNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoiceDetails");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
