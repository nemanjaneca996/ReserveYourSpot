using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class AddedDescriptiontoLocales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTimeId",
                table: "Locales");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locales");

            migrationBuilder.AddColumn<int>(
                name: "WorkTimeId",
                table: "Locales",
                nullable: false,
                defaultValue: 0);
        }
    }
}
