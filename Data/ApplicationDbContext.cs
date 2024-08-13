using f1_predictions.Models;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace f1_predictions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonParticipation> SeasonParticipations { get; set; }
        public DbSet<GrandPrix> GrandPrixes { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any additional Fluent API configurations here, if needed
        }
    }
}
