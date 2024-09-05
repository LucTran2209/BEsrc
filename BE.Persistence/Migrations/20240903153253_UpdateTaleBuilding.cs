using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaleBuilding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingDescription",
                table: "Bulding");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingName",
                table: "Bulding",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bulding",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                table: "Bulding",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Bulding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactNumber",
                table: "Bulding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "Bulding",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Bulding",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsValiable",
                table: "Bulding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Bulding",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Bulding",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloor",
                table: "Bulding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearConstucted",
                table: "Bulding",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "IsValiable",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "NumberOfFloor",
                table: "Bulding");

            migrationBuilder.DropColumn(
                name: "YearConstucted",
                table: "Bulding");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingName",
                table: "Bulding",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "BuildingDescription",
                table: "Bulding",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
