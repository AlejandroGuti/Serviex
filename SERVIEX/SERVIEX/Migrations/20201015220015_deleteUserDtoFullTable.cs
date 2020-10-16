using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SERVIEX.Migrations
{
    public partial class deleteUserDtoFullTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullUserDTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullUserDTO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    genderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullUserDTO", x => x.id);
                    table.ForeignKey(
                        name: "FK_FullUserDTO_genders_genderid",
                        column: x => x.genderid,
                        principalTable: "genders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FullUserDTO_genderid",
                table: "FullUserDTO",
                column: "genderid");
        }
    }
}
