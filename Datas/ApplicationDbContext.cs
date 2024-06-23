
using GameStore.FrontEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.FrontEnd.Datas
{
    public class ApplicationDbContext : DbContext
    {
        // Add your DbSet properties here
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GameDetails> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection here
        }
    }
}
