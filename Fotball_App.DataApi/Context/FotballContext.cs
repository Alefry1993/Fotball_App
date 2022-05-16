using Fotball_App.DataApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //Leagues
            modelBuilder.Entity<League>().HasData(new League { LeagueId = 1, LeagueName = "Premier League", Nationality = "England" });
            modelBuilder.Entity<League>().HasData(new League { LeagueId = 2, LeagueName = "La Liga", Nationality = "Spain" });
            modelBuilder.Entity<League>().HasData(new League { LeagueId = 3, LeagueName = "Ligue 1", Nationality = "France" });
            modelBuilder.Entity<League>().HasData(new League { LeagueId = 4, LeagueName = "Serie A", Nationality = "Italia" });
            modelBuilder.Entity<League>().HasData(new League { LeagueId = 5, LeagueName = "Bundesliga", Nationality = "Germany" });

            //Teams
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = 1, TeamName = "Manchester United", TeamDescription = "One of the biggest clubs in the premier league with a total of 20 league titles. They are one of the top 6 clubs in the league.", TeamLogo = "ManUtd.png");
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = 2, TeamName = "Real Madrid", TeamDescription = "One of the biggest clubs in the premier league with a total of 20 league titles. They are one of the top 6 clubs in the league.", TeamLogo = "ManUtd.png");
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = 3, TeamName = "Borrussia Dortmund", TeamDescription = "One of the biggest clubs in the premier league with a total of 20 league titles. They are one of the top 6 clubs in the league.", TeamLogo = "ManUtd.png");
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = 4, TeamName = "Juventus", TeamDescription = "One of the biggest clubs in the premier league with a total of 20 league titles. They are one of the top 6 clubs in the league.", TeamLogo = "ManUtd.png");
            modelBuilder.Entity<Team>().HasData(new Team { TeamId = 5, TeamName = "Paris Saint Germain", TeamDescription = "One of the biggest clubs in the premier league with a total of 20 league titles. They are one of the top 6 clubs in the league.", TeamLogo = "ManUtd.png");

            //Players
            modelBuilder.Entity<Player>().HasData(new Player {PlayerId = 1, PlayerName = "Cristiano Ronaldo", National = "Portugal" , Age = 38 , ProfileImage = "Ronaldo.jpg" , club = 1});
            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 2, PlayerName = "Karim Benzema", National = "France", Age = 38, ProfileImage = "Karim.jpg", club = 1 });
            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 3, PlayerName = "Marco Reus", National = "Germany", Age = 38, ProfileImage = "Robert.jpg", club = 1 });
            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 4, PlayerName = "Alex Sandro", National = "Brazil", Age = 38, ProfileImage = "Neymar.jpg", club = 1 });
            modelBuilder.Entity<Player>().HasData(new Player { PlayerId = 5, PlayerName = "Lionel Messi", National = "Argentina", Age = 38, ProfileImage = "Lautaro.jpg", club = 1 });
        } 
    }
}
