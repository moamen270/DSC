using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditMediaPropertiesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Media",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Media",
                newName: "PublicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Media",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Media",
                newName: "ImageId");
        }
    }
}
