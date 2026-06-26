using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FermentationControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FermentationParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TemperatureMin = table.Column<decimal>(type: "TEXT", nullable: false),
                    TemperatureMax = table.Column<decimal>(type: "TEXT", nullable: false),
                    PHMin = table.Column<decimal>(type: "TEXT", nullable: false),
                    PHMax = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExtractMin = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExtractMax = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermentationParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FermentationParameters_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FermentationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TankId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Temperature = table.Column<decimal>(type: "TEXT", nullable: false),
                    PH = table.Column<decimal>(type: "TEXT", nullable: false),
                    Extract = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermentationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FermentationRecords_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FermentationRecords_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FermentationParameters_BeerId",
                table: "FermentationParameters",
                column: "BeerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FermentationRecords_BeerId",
                table: "FermentationRecords",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_FermentationRecords_TankId",
                table: "FermentationRecords",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FermentationParameters");

            migrationBuilder.DropTable(
                name: "FermentationRecords");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}
