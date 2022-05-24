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
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Founded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Height = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "PlayersInTeams",
                columns: table => new
                {
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false),
                    PlayersPlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersInTeams", x => new { x.TeamsTeamId, x.PlayersPlayerId });
                    table.ForeignKey(
                        name: "FK_PlayersInTeams_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersInTeams_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "About", "Founded", "LeagueLogo", "LeagueName", "Nationality" },
                values: new object[,]
                {
                    { 1, "Top league in england", "20 February 1992", "England.png", "Premier League", "England" },
                    { 2, "Top league in Spain", "15 June 1929", "Spain.png", "La Liga", "Spain" },
                    { 3, "Top league in France", "11 September 1932", "France.png", "Ligue 1", "France" },
                    { 4, "Top league in Italy", "13 August 1929", "Italia.png", "Serie A", "Italia" },
                    { 5, "Top league in Germany", "28 July 1962", "Germany.png", "Bundesliga", "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "About", "Age", "Height", "National", "PlayerName", "Position", "ProfileImage" },
                values: new object[,]
                {
                    { 1, "Player in Manchester United", 37, 189, "Portugal", "Cristiano Ronaldo", "Forward", "Ronaldo.jpg" },
                    { 2, "Player in Real Madrid", 34, 185, "France", "Karim Benzema", "Forward", "Karim.jpg" },
                    { 3, "Player in Dortmund", 32, 180, "Germany", "Marco Reus", "Midfielder", "Reus.jpg" },
                    { 4, "Player in Juventus", 31, 177, "Brazil", "Alex Sandro", "Defender", "Alex.jpg" },
                    { 5, "Player in PSG", 34, 169, "Argentina", "Lionel Messi", "Forward", "Messi.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Country", "Manager", "TeamDescription", "TeamLogo", "TeamName" },
                values: new object[,]
                {
                    { 1, "England", "Erik Ten Hag", "Manchester United Football Club is a professional football club, that competes in the Premier League, the top flight of English football. \n\n Manchester United is one of the most successful clubs in English football, having won a record 20 League titles, 12 FA Cups, five League Cups and a record 21 FA Community Shields.They have won the European Cup/ UEFA Champions League three times, and the UEFA Europa League. \n\n Alex Ferguson is the club's longest-serving and most successful manager, winning 38 trophies.", "ManUtd.png", "Manchester United" },
                    { 2, "Spain", "Carlo Ancelotti", "Real Madrid Club de Fútbol, commonly referred to as Real Madrid or simply Real, is a Spanish professional football club based in Madrid. Founded on 6 March 1902 as Madrid Football Club. The team has played its home matches in the 81,044-capacity Santiago Bernabéu Stadium in downtown Madrid since 1947. \n\n In domestic football, the club has won 68 trophies; a record 35 La Liga titles, 19 Copa del Rey, 12 Supercopa de España, a Copa Eva Duarte, and a Copa de la Liga.In European football, Real Madrid have won a record 19 trophies; a record 13 European Cup/ UEFA Champions League titles, two UEFA Cups and four UEFA Super Cup.", "RealMadrid.png", "Real Madrid" },
                    { 3, "Germany", "Edin Terzic", "Ballspielverein Borussia 09 e. V. Dortmund, commonly known as Borussia Dortmund, BVB  or simply Dortmund, is a German professional sports club based in Dortmund, North Rhine-Westphalia. They play in the Bundesliga, the top tier of the German football league system. \n\n The club have won eight league championships, five DFB-Pokals, one UEFA Champions League, one Intercontinental Cup, and one UEFA Cup Winners' Cup.", "Dortmund.png", "Borrussia Dortmund" },
                    { 4, "Italy", "Massimiliano Allegri", "Juventus Football Club, commonly known as Juventus, or simply Juve is a professional football club based in Turin, Piedmont, Italy, that competes in the Serie A, the top tier of the Italian football league system. \n\n The club has won 36 official league titles, 14 Coppa Italia titles and nine Supercoppa Italiana titles, being the record holder for all these competitions; two Intercontinental Cups, two European Cups / UEFA Champions Leagues, one European Cup Winners' Cup, a joint national record of three UEFA Cups, two UEFA Super Cups and a joint national record of one UEFA Intertoto Cup.", "Juventus.png", "Juventus" },
                    { 5, "France", "Mauricio Pochettino", "Paris Saint-Germain Football Club commonly referred to as Paris Saint-Germain, Paris, Paris SG or simply PSG is a professional football club based in Paris, France. They compete in Ligue 1, the top division of French football. As France's most successful club, they have won over 40 official honours, including ten league titles and one major European trophy. Their home ground is the Parc des Princes.\n\n PSG have also become a regular feature in the UEFA Champions League, reaching their first final in 2020.PSG also won the league this year 21 / 22. ", "Psg.png", "Paris Saint Germain" }
                });

            migrationBuilder.InsertData(
                table: "PlayersInTeams",
                columns: new[] { "PlayersPlayerId", "TeamsTeamId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
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

            migrationBuilder.CreateIndex(
                name: "IX_PlayersInTeams_PlayersPlayerId",
                table: "PlayersInTeams",
                column: "PlayersPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInLeague_TeamTeamsId",
                table: "TeamsInLeague",
                column: "TeamTeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersInTeams");

            migrationBuilder.DropTable(
                name: "TeamsInLeague");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
