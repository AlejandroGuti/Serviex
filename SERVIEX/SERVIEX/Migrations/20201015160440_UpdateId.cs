using Microsoft.EntityFrameworkCore.Migrations;

namespace SERVIEX.Migrations
{
    public partial class UpdateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idGender",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idGender",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
