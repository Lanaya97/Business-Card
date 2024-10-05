using Microsoft.EntityFrameworkCore;


namespace BusinessCard.Infrastructure.DatabaseContext
{
    public partial class BusinessCardContext : DbContext
    {
        DbSet<BusinessCard.Domain.BusinessCard> BusinessCards { get; set; }

        public BusinessCardContext(DbContextOptions<BusinessCardContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
