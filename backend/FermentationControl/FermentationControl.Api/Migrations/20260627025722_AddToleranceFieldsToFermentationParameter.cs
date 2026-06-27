using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FermentationControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddToleranceFieldsToFermentationParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "FermentationRecords",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtractTolerance",
                table: "FermentationParameters",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PHTolerance",
                table: "FermentationParameters",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TemperatureTolerance",
                table: "FermentationParameters",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtractTolerance",
                table: "FermentationParameters");

            migrationBuilder.DropColumn(
                name: "PHTolerance",
                table: "FermentationParameters");

            migrationBuilder.DropColumn(
                name: "TemperatureTolerance",
                table: "FermentationParameters");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "FermentationRecords",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
