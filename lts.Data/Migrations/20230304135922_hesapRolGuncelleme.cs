using Microsoft.EntityFrameworkCore.Migrations;

namespace lts.Data.Migrations
{
    public partial class hesapRolGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "AspNetRoles");
        }
    }
}
