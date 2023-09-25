using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotNet_OneToMany_Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sportsonetomany.db");


        // DBSet<Leagues/Teams/Players> directly connected to the DataController's static tables AND/OR Models(not sure which comes first, but tested while renaming one of the tables) - Not sure about PlayerTeam
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
    }
}
