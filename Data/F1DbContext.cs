using f1_predictions.Models;
using Microsoft.EntityFrameworkCore;

namespace f1_predictions.Data
{
    public class F1DbContext : DbContext
    {
        public F1DbContext(DbContextOptions<F1DbContext> options) : base(options) { }

        public DbSet<GrandPrix> GrandPrixes { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonParticipation> SeasonParticipations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "GameMaster" },
                new Role { Id = Guid.NewGuid(), Name = "Player" }
            );

            modelBuilder.Entity<Season>()
                .HasMany(s => s.GrandPrixes)
                .WithOne(gp => gp.Season)
                .HasForeignKey(gp => gp.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(p => p.GrandPrix)
                .WithMany()
                .HasForeignKey(p => p.GpId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(p => p.Player)
                .WithMany()
                .HasForeignKey(p => p.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeasonParticipation>()
                .HasOne(sp => sp.Participant)
                .WithMany()
                .HasForeignKey(sp => sp.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeasonParticipation>()
                .HasOne(sp => sp.Season)
                .WithMany()
                .HasForeignKey(sp => sp.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
