using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editArtical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Articles");
        }
    }
}
