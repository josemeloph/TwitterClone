using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Migrations
{
    public partial class Curtidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Tweets_TweetId",
                table: "Curtidas");

            migrationBuilder.DropIndex(
                name: "IX_Curtidas_TweetId",
                table: "Curtidas");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Tweets",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Tweets");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_TweetId",
                table: "Curtidas",
                column: "TweetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Tweets_TweetId",
                table: "Curtidas",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
