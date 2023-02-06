using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCDStore.Migrations
{
    /// <inheritdoc />
    public partial class audit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Adds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Adds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
