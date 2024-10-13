using Microsoft.EntityFrameworkCore;


namespace BusinessCard.Infrastructure.DatabaseContext
{

    public partial class ApplicationDbContext : DbContext
    {
        const string SCHEMA = "BusinessCardSchema";

        public DbSet<Domain.BusinessCard> BusinessCards { get; set; }

        private ApplicationDbContext() 
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domain.BusinessCard>(entity =>
            {

                entity.ToTable(nameof(Domain.BusinessCard));


                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Photo).HasMaxLength(65535);

                entity.Property(e => e.Gender)
                    .HasConversion<string>() 
                    .IsRequired();

                entity.HasIndex(e => e.Email).IsUnique();


                entity.OwnsOne(e => e.Address, a =>
                {
                    a.WithOwner();
                    a.Property(p => p.Street).HasColumnName("Street").IsRequired();
                    a.Property(p => p.City).HasColumnName("City").IsRequired();
                    a.Property(p => p.ZipCode).HasColumnName("ZipCode").IsRequired();

                    // Create unique index for PhoneNumber

                });

                entity.OwnsOne(e => e.PhoneNumber, a =>
                {
                    a.WithOwner();
                    a.Property(p => p.CountryCode).HasColumnName("CountryCode").IsRequired().HasMaxLength(4);
                    a.Property(p => p.Number).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(10);

                    a.HasIndex(p => p.Number).IsUnique();

                });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
