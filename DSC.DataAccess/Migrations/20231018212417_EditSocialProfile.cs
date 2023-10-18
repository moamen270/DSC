using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditSocialProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "SocialProfiles");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SocialProfiles",
                newName: "Icon");

            migrationBuilder.AddColumn<int>(
                name: "Profile",
                table: "SocialProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile",
                table: "SocialProfiles");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "SocialProfiles",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "SocialProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
