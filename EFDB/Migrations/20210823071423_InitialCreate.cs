using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_games_GameId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_GameId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "WinnerIndex",
                table: "games",
                newName: "WinnerId");

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesWon",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1",
                table: "games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2",
                table: "games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "users");

            migrationBuilder.DropColumn(
                name: "GamesWon",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Player1",
                table: "games");

            migrationBuilder.DropColumn(
                name: "Player2",
                table: "games");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                table: "games",
                newName: "WinnerIndex");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_GameId",
                table: "users",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_games_GameId",
                table: "users",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
