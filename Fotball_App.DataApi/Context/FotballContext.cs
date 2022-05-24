using Fotball_App.DataApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Fotball_App.DataApi.Context
{
    public class FotballContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=Donau.hiof.no;Database=aleksanf;User=aleksanf;Password=tGUNK2qLSg");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new LeagueEntityTypeConfiguration().Configure(modelBuilder.Entity<League>());
            new TeamEntityTypeConfiguration().Configure(modelBuilder.Entity<Team>());
            new PlayerEntityTypeConfiguration().Configure(modelBuilder.Entity<Player>());
        }

        public class LeagueEntityTypeConfiguration : IEntityTypeConfiguration<League>
        {
            public void Configure(EntityTypeBuilder<League> builder)
            {
                #region Seeding Leagues
                builder.HasData(new League { LeagueId = 1, LeagueName = "Premier League", LeagueLogo = "England.png", Nationality = "England", About = "Top league in england", Founded = "20 February 1992" });

                builder.HasData(new League { LeagueId = 2, LeagueName = "La Liga", LeagueLogo = "Spain.png", Nationality = "Spain", About = "Top league in Spain", Founded = "15 June 1929" });

                builder.HasData(new League { LeagueId = 3, LeagueName = "Ligue 1", LeagueLogo = "France.png", Nationality = "France", About = "Top league in France", Founded = "11 September 1932" });

                builder.HasData(new League { LeagueId = 4, LeagueName = "Serie A", LeagueLogo = "Italia.png", Nationality = "Italia", About = "Top league in Italy", Founded = "13 August 1929" });

                builder.HasData(new League { LeagueId = 5, LeagueName = "Bundesliga", LeagueLogo = "Germany.png", Nationality = "Germany", About = "Top league in Germany", Founded = "28 July 1962" });
                #endregion

                #region Teams in league
                builder
               .HasMany(l => l.Teams)
               .WithMany(t => t.League)
               .UsingEntity<Dictionary<string, object>>(
                   "TeamsInLeague",
                   r => r.HasOne<Team>().WithMany().HasForeignKey("TeamTeamsId"),
                   l => l.HasOne<League>().WithMany().HasForeignKey("LeaguesLeagueId"),
                   je =>
                   {
                       je.HasKey("LeaguesLeagueId", "TeamTeamsId");
                       je.HasData(

                       #region Premier league Teams
                            new { LeaguesLeagueId = 1, TeamTeamsId = 1 },
                       #endregion

                       #region La liga Teams
                        new { LeaguesLeagueId = 2, TeamTeamsId = 2 },
                       #endregion

                       #region Bundesliga Teams
                        new { LeaguesLeagueId = 3, TeamTeamsId = 5 },
                       #endregion

                       #region Serie A Teams
                       new { LeaguesLeagueId = 4, TeamTeamsId = 4 },
                       #endregion

                       #region Ligue 1 Teams
                        new { LeaguesLeagueId = 5, TeamTeamsId = 3 });
                       #endregion


                   });
                #endregion
            }
        }

        public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
        {
            public void Configure(EntityTypeBuilder<Team> builder)
            {
                #region Seeding Teams
                var UnitedDescription = "Manchester United Football Club is a professional football club, that competes in the Premier League, the top flight of English football. \n\n Manchester United is one of the most successful clubs in English football, having won a record 20 League titles, 12 FA Cups, five League Cups and a record 21 FA Community Shields.They have won the European Cup/ UEFA Champions League three times, and the UEFA Europa League. \n\n Alex Ferguson is the club's longest-serving and most successful manager, winning 38 trophies.";

                var RealDescription = "Real Madrid Club de Fútbol, commonly referred to as Real Madrid or simply Real, is a Spanish professional football club based in Madrid. Founded on 6 March 1902 as Madrid Football Club. The team has played its home matches in the 81,044-capacity Santiago Bernabéu Stadium in downtown Madrid since 1947. \n\n In domestic football, the club has won 68 trophies; a record 35 La Liga titles, 19 Copa del Rey, 12 Supercopa de España, a Copa Eva Duarte, and a Copa de la Liga.In European football, Real Madrid have won a record 19 trophies; a record 13 European Cup/ UEFA Champions League titles, two UEFA Cups and four UEFA Super Cup.";

                var DortmundDescription = "Ballspielverein Borussia 09 e. V. Dortmund, commonly known as Borussia Dortmund, BVB  or simply Dortmund, is a German professional sports club based in Dortmund, North Rhine-Westphalia. They play in the Bundesliga, the top tier of the German football league system. \n\n The club have won eight league championships, five DFB-Pokals, one UEFA Champions League, one Intercontinental Cup, and one UEFA Cup Winners' Cup.";

                var PsgDescription = "Paris Saint-Germain Football Club commonly referred to as Paris Saint-Germain, Paris, Paris SG or simply PSG is a professional football club based in Paris, France. They compete in Ligue 1, the top division of French football. As France's most successful club, they have won over 40 official honours, including ten league titles and one major European trophy. Their home ground is the Parc des Princes.\n\n PSG have also become a regular feature in the UEFA Champions League, reaching their first final in 2020.PSG also won the league this year 21 / 22. ";

                var JuventusDescription = "Juventus Football Club, commonly known as Juventus, or simply Juve is a professional football club based in Turin, Piedmont, Italy, that competes in the Serie A, the top tier of the Italian football league system. \n\n The club has won 36 official league titles, 14 Coppa Italia titles and nine Supercoppa Italiana titles, being the record holder for all these competitions; two Intercontinental Cups, two European Cups / UEFA Champions Leagues, one European Cup Winners' Cup, a joint national record of three UEFA Cups, two UEFA Super Cups and a joint national record of one UEFA Intertoto Cup.";

                builder.HasData(new Team { TeamId = 1, TeamName = "Manchester United", TeamDescription = UnitedDescription, TeamLogo = "ManUtd.png", Country = "England", Manager = "Erik Ten Hag" });

                builder.HasData(new Team { TeamId = 2, TeamName = "Real Madrid", TeamDescription = RealDescription, TeamLogo = "RealMadrid.png", Country = "Spain", Manager = "Carlo Ancelotti" });

                builder.HasData(new Team { TeamId = 3, TeamName = "Borrussia Dortmund", TeamDescription = DortmundDescription, TeamLogo = "Dortmund.png", Country = "Germany", Manager = "Edin Terzic" });

                builder.HasData(new Team { TeamId = 4, TeamName = "Juventus", TeamDescription = JuventusDescription, TeamLogo = "Juventus.png", Country = "Italy", Manager = "Massimiliano Allegri" });

                builder.HasData(new Team { TeamId = 5, TeamName = "Paris Saint Germain", TeamDescription = PsgDescription, TeamLogo = "Psg.png", Country = "France", Manager = "Mauricio Pochettino" });
                #endregion

                #region player in team
                builder
                .HasMany(t => t.players)
                .WithMany(p => p.club)
                .UsingEntity<Dictionary<string, object>>(
                    "PlayersInTeams",
                    r => r.HasOne<Player>().WithMany().HasForeignKey("PlayersPlayerId"),
                    l => l.HasOne<Team>().WithMany().HasForeignKey("TeamsTeamId"),
                    je =>
                    {
                        je.HasKey("TeamsTeamId", "PlayersPlayerId");
                        je.HasData(

                        #region Manchester United Players
                            new { TeamsTeamId = 1, PlayersPlayerId = 1 },
                        #endregion

                        #region Real Madrid Players
                        new { TeamsTeamId = 2, PlayersPlayerId = 2 },
                        #endregion

                        #region Borrussia Dortmund Players
                        new { TeamsTeamId = 3, PlayersPlayerId = 3 },
                        #endregion

                        #region Juventus Players
                        new { TeamsTeamId = 4, PlayersPlayerId = 4 },
                        #endregion

                        #region PSG Players
                        new { TeamsTeamId = 5, PlayersPlayerId = 5 });
                        #endregion





                    });
                #endregion
            }
        }




        public class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
        {
            public void Configure(EntityTypeBuilder<Player> builder)
            {
                #region Seeding Players
                builder.HasData(new Player { PlayerId = 1, PlayerName = "Cristiano Ronaldo", National = "Portugal", Age = 37, Height = 189, Position = "Forward", ProfileImage = "Ronaldo.jpg", About = "Player in Manchester United" });

                builder.HasData(new Player { PlayerId = 2, PlayerName = "Karim Benzema", National = "France", Age = 34, Height = 185, Position = "Forward", ProfileImage = "Karim.jpg", About = "Player in Real Madrid" });

                builder.HasData(new Player { PlayerId = 3, PlayerName = "Marco Reus", National = "Germany", Age = 32, Height = 180, Position = "Midfielder", ProfileImage = "Reus.jpg", About = "Player in Dortmund" });

                builder.HasData(new Player { PlayerId = 4, PlayerName = "Alex Sandro", National = "Brazil", Age = 31, Height = 177, Position = "Defender", ProfileImage = "Alex.jpg", About = "Player in Juventus" });

                builder.HasData(new Player { PlayerId = 5, PlayerName = "Lionel Messi", National = "Argentina", Age = 34, Height = 169, Position = "Forward", ProfileImage = "Messi.jpg", About = "Player in PSG" });
                #endregion

            }

        }
    }
}
