using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fixnameBuildings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bulding",
                table: "Bulding");

            migrationBuilder.RenameTable(
                name: "Bulding",
                newName: "Buldings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buldings",
                table: "Buldings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buldings",
                table: "Buldings");

            migrationBuilder.RenameTable(
                name: "Buldings",
                newName: "Bulding");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bulding",
                table: "Bulding",
                column: "Id");
        }
    }
}
