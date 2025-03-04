using f1_predictions.Core;
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

            var adminRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var gameMasterRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var PlayerRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? "Parola.1!";

            var adminUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var gameMasterUserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = adminRoleId, Name = "Admin" },
                new Role { Id = gameMasterRoleId, Name = "GameMaster" },
                new Role { Id = PlayerRoleId, Name = "Player" }
            );

            modelBuilder.Entity<User>().HasData(
      new User
      {
          Id = adminUserId,
          Username = "admin",
          Email = "admin@f1goes.br",
          Password = Helpers.HashPassword(adminPassword), // Hash the env var password
          RoleId = adminRoleId,
          Role = default!

      },
      new User
      {
          Id = gameMasterUserId,
          Username = "Game Master",
          Email = "gamemaster@f1goes.br",
          Password = Helpers.HashPassword(adminPassword), // Hash the env var password
          RoleId = adminRoleId,
          Role = default!
      }
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
