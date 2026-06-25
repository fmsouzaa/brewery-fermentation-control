using FermentationControl.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FermentationControl.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<FermentationParameter> FermentationParameters { get; set; }

        public DbSet<FermentationRecord> FermentationRecords { get; set; }

        public DbSet<Tank> Tanks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura o relacionamento 1 para 1 entre Beer e FermentationParameter
            modelBuilder.Entity<Beer>()
                .HasOne(b => b.FermentationParameter)
                .WithOne(p => p.Beer)
                .HasForeignKey<FermentationParameter>(p => p.BeerId);

            // Configura o relacionamento 1 para muitos entre Beer e FermentationRecord
            modelBuilder.Entity<Beer>()
                .HasMany(b => b.FermentationRecords)
                .WithOne(r => r.Beer)
                .HasForeignKey(r => r.BeerId);

            // Configura o relacionamento 1 para muitos entre Tank e FermentationRecord
            modelBuilder.Entity<Tank>()
                .HasMany(t => t.FermentationRecords)
                .WithOne(r => r.Tank)
                .HasForeignKey(r => r.TankId);
        }
    }
}
