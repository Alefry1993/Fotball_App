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
                builder.HasData(new League { LeagueId = 1, LeagueName = "Premier League", LeagueLogo = "England.png", Nationality = "England" });

                builder.HasData(new League { LeagueId = 2, LeagueName = "La Liga", LeagueLogo = "Spain.png", Nationality = "Spain" });

                builder.HasData(new League { LeagueId = 3, LeagueName = "Ligue 1", LeagueLogo = "France.png", Nationality = "France" });

                builder.HasData(new League { LeagueId = 4, LeagueName = "Serie A", LeagueLogo = "Italia.png", Nationality = "Italia" });

                builder.HasData(new League { LeagueId = 5, LeagueName = "Bundesliga", LeagueLogo = "Germany.png", Nationality = "Germany" });
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
                var description = "One of the biggest clubs in the English league: Premier League. They have a total of 20 league titles. They are one of the top 6 clubs in the league.";
                builder.HasData(new Team { TeamId = 1, TeamName = "Manchester United", TeamDescription = description, TeamLogo = "ManUtd.png", Country = "England" });

                description = "One of the biggest clubs in the Spanish league: La Liga";
                builder.HasData(new Team { TeamId = 2, TeamName = "Real Madrid", TeamDescription = description, TeamLogo = "RealMadrid.png", Country = "Spain" });

                description = "One of the biggest clubs in the German League: Bundesliga";
                builder.HasData(new Team { TeamId = 3, TeamName = "Borrussia Dortmund", TeamDescription = description, TeamLogo = "Dortmund.png", Country = "Germany" });

                description = "One of the biggest clubs in the Italien league: Serie A";
                builder.HasData(new Team { TeamId = 4, TeamName = "Juventus", TeamDescription = description, TeamLogo = "Juventus.png", Country = "Italy" });

                description = "One of the biggest clubs in the French league: Ligue 1";
                builder.HasData(new Team { TeamId = 5, TeamName = "Paris Saint Germain", TeamDescription = description, TeamLogo = "Psg.png", Country = "France" });
                #endregion

                #region player in team
                builder
                .HasMany(t => t.players)
                .WithMany(p => p.club)
                .UsingEntity<Dictionary<string, object>>(
                    "TeamsInPlayers",
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
                builder.HasData(new Player { PlayerId = 1, PlayerName = "Cristiano Ronaldo", National = "Portugal", Age = 38, ProfileImage = "Ronaldo.jpg" });

                builder.HasData(new Player { PlayerId = 2, PlayerName = "Karim Benzema", National = "France", Age = 34, ProfileImage = "Karim.jpg" });

                builder.HasData(new Player { PlayerId = 3, PlayerName = "Marco Reus", National = "Germany", Age = 32, ProfileImage = "Reus.jpg" });

                builder.HasData(new Player { PlayerId = 4, PlayerName = "Alex Sandro", National = "Brazil", Age = 31, ProfileImage = "Alex.jpg" });

                builder.HasData(new Player { PlayerId = 5, PlayerName = "Lionel Messi", National = "Argentina", Age = 34, ProfileImage = "Messi.jpg" });
                #endregion

            }

        }
    }
}
