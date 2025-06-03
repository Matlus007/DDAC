using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week3_MVCFlowerShop.Migrations
{
    /// <inheritdoc />
    public partial class addNewFlowerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowerTable",
                columns: table => new
                {
                    FlowerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlowerProducedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlowerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerTable", x => x.FlowerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerTable");
        }
    }
}
