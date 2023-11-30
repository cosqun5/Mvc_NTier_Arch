using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class createconcattype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactType",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactType",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactType",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "ContactType",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
