using Microsoft.EntityFrameworkCore.Migrations;

namespace ddl_test.Migrations
{
    public partial class alterstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "sutdents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "sutdents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "sutdents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "sutdents");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "sutdents");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "sutdents");
        }
    }
}
