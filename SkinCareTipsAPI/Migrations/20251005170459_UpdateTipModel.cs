using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkinCareTipsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Tips",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tips",
                newName: "Category");
        }
    }
}
