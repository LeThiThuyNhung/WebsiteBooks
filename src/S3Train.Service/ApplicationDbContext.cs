using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace S3Train.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductAdvertisement> ProductAdvertisements { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Summary).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Barcode).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ReleaseYear).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Amount).IsRequired();

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithRequired(p => p.Category);
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Publisher>().HasMany(c => c.Products).WithRequired(p => p.Publisher);
            modelBuilder.Entity<Publisher>().Property(x => x.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ProductAdvertisement>().ToTable("ProductAdvertisement");
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.EventUrl).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Title).HasMaxLength(100).IsOptional();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Description).HasMaxLength(500).IsOptional();
        }
        
    }
}