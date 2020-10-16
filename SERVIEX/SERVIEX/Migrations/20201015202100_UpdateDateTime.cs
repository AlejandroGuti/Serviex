using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SERVIEX.Migrations
{
    public partial class UpdateDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullUserDTO",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    BornDate = table.Column<DateTime>(nullable: false),
                    genderid = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullUserDTO");
        }
    }
}
