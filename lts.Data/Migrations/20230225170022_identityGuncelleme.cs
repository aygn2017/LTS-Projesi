using Microsoft.EntityFrameworkCore.Migrations;

namespace lts.Data.Migrations
{
    public partial class identityGuncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeciciSifre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeciciSifre",
                table: "AspNetUsers");
        }
    }
}
