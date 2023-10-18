using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImageIdToMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Media",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Media",
                newName: "MediaType");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "MediaType",
                table: "Media",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Media",
                newName: "Url");
        }
    }
}
