using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Migrations
{
    public partial class Curtidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Curtidas",
                table: "Tweets",
                newName: "NumCurtidas");

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TweetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curtidas_Tweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "Tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curtidas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_TweetId",
                table: "Curtidas",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_UsuarioId",
                table: "Curtidas",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.RenameColumn(
                name: "NumCurtidas",
                table: "Tweets",
                newName: "Curtidas");
        }
    }
}
