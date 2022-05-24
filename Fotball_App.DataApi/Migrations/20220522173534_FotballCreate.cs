using Microsoft.EntityFrameworkCore.Migrations;

namespace Fotball_App.DataApi.Migrations
{
    public partial class FotballCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    National = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInLeague",
                columns: table => new
                {
                    LeaguesLeagueId = table.Column<int>(type: "int", nullable: false),
                    TeamTeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInLeague", x => new { x.LeaguesLeagueId, x.TeamTeamsId });
                    table.ForeignKey(
                        name: "FK_TeamsInLeague_Leagues_LeaguesLeagueId",
                        column: x => x.LeaguesLeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsInLeague_Teams_TeamTeamsId",
                        column: x => x.TeamTeamsId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInPlayers",
                columns: table => new
                {
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false),
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInPlayers", x => new { x.TeamsTeamId, x.PlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_TeamsInPlayers_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsInPlayers_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "LeagueLogo", "LeagueName", "Nationality" },
                values: new object[,]
                {
                    { 1, "England.png", "Premier League", "England" },
                    { 2, "Spain.png", "La Liga", "Spain" },
                    { 3, "France.png", "Ligue 1", "France" },
                    { 4, "Italia.png", "Serie A", "Italia" },
                    { 5, "Germany.png", "Bundesliga", "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "National", "PlayerName", "ProfileImage" },
                values: new object[,]
                {
                    { 1, 38, "Portugal", "Cristiano Ronaldo", "Ronaldo.jpg" },
                    { 2, 34, "France", "Karim Benzema", "Karim.jpg" },
                    { 3, 32, "Germany", "Marco Reus", "Reus.jpg" },
                    { 4, 31, "Brazil", "Alex Sandro", "Alex.jpg" },
                    { 5, 34, "Argentina", "Lionel Messi", "Messi.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Country", "TeamDescription", "TeamLogo", "TeamName" },
                values: new object[,]
                {
                    { 1, "England", "One of the biggest clubs in the English league: Premier League. They have a total of 20 league titles. They are one of the top 6 clubs in the league.", "ManUtd.png", "Manchester United" },
                    { 2, "Spain", "One of the biggest clubs in the Spanish league: La Liga", "RealMadrid.png", "Real Madrid" },
                    { 3, "Germany", "One of the biggest clubs in the German League: Bundesliga", "Dortmund.png", "Borrussia Dortmund" },
                    { 4, "Italy", "One of the biggest clubs in the Italien league: Serie A", "Juventus.png", "Juventus" },
                    { 5, "France", "One of the biggest clubs in the French league: Ligue 1", "Psg.png", "Paris Saint Germain" }
                });

            migrationBuilder.InsertData(
                table: "TeamsInLeague",
                columns: new[] { "LeaguesLeagueId", "TeamTeamsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 5, 3 },
                    { 4, 4 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "TeamsInPlayers",
                columns: new[] { "PlayersPlayerId", "TeamsTeamId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInLeague_TeamTeamsId",
                table: "TeamsInLeague",
                column: "TeamTeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInPlayers_PlayersPlayerId",
                table: "TeamsInPlayers",
                column: "PlayersPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsInLeague");

            migrationBuilder.DropTable(
                name: "TeamsInPlayers");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
