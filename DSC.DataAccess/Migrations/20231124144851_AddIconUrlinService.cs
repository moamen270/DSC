using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIconUrlinService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Services");
        }
    }
}
