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
        public DbSet<Position> Positions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author_Product> Author_Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDetail> PromotionDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasMany(c => c.Author_Products).WithRequired(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(c => c.PromotionDetails).WithRequired(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(c => c.ProductAdvertisement).WithRequired(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(c => c.OrderDetails).WithRequired(p => p.Product);
            modelBuilder.Entity<Product>().Property(x => x.NameProduct).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Summary).HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Barcode).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ReleaseYear).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Amount).IsRequired();

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithRequired(p => p.Category);
            modelBuilder.Entity<Category>().Property(x => x.NameCategory).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Publisher>().HasMany(c => c.Products).WithRequired(p => p.Publisher);
            modelBuilder.Entity<Publisher>().Property(x => x.NamePublisher).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ProductAdvertisement>().ToTable("ProductAdvertisement");
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.EventUrl).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Title).HasMaxLength(100).IsOptional();
            modelBuilder.Entity<ProductAdvertisement>().Property(x => x.Description).HasMaxLength(500).IsOptional();

            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Staff>().Property(x => x.NameStaff).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.ImagePath).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Address).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Sex).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.DateOfBirth).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Email).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Password).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Position>().HasMany(c => c.Staffs).WithRequired(p => p.Position);
            modelBuilder.Entity<Position>().Property(x => x.NamePosition).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Author>().HasMany(c => c.Author_Products).WithRequired(p => p.Author);
            modelBuilder.Entity<Author>().Property(x => x.NameAuthor).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Author_Product>().ToTable("Author_Product");
            modelBuilder.Entity<Author_Product>().Property(x => x.Role).HasMaxLength(100);

            modelBuilder.Entity<Promotion>().ToTable("Promotion");
            modelBuilder.Entity<Promotion>().HasMany(c => c.PromotionDetails).WithRequired(p => p.Promotion);
            modelBuilder.Entity<Promotion>().Property(x => x.PromotionName).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Promotion>().Property(x => x.StartTime).IsRequired();
            modelBuilder.Entity<Promotion>().Property(x => x.EndTime).IsRequired();

            modelBuilder.Entity<PromotionDetail>().ToTable("PromotionDetail");
            modelBuilder.Entity<PromotionDetail>().Property(x => x.PromotionPercent).IsRequired();

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Order>().HasMany(c => c.OrderDetails).WithRequired(p => p.Order);
            modelBuilder.Entity<Order>().Property(x => x.DatePayment);
            modelBuilder.Entity<Order>().Property(x => x.Status).HasMaxLength(100);
            modelBuilder.Entity<Order>().Property(x => x.Note).HasMaxLength(300);
            modelBuilder.Entity<Order>().Property(x => x.TotalMoney);

            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<OrderDetail>().Property(x => x.OrderQuantity).IsRequired();
            modelBuilder.Entity<OrderDetail>().Property(x => x.Total).IsRequired();
            modelBuilder.Entity<OrderDetail>().Property(x => x.Price).IsRequired();
        }
        
    }
}