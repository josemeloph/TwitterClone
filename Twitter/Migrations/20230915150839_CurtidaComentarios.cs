using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Migrations
{
    public partial class CurtidaComentarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "Curtidas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "Curtidas");
        }
    }
}
