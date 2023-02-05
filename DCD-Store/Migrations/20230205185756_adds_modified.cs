using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCDStore.Migrations
{
    /// <inheritdoc />
    public partial class addsmodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Adds");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Adds");
        }
    }
}
