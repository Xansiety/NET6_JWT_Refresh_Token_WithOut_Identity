using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET6_WEB_API_TEMPLATE_JWT.Migrations
{
    public partial class UpdateUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                schema: "TI",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "TI",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                schema: "TI",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "TI",
                table: "Usuario");
        }
    }
}
