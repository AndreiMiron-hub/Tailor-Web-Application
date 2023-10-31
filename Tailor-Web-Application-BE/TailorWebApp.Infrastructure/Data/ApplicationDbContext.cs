using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TailorWebApp.Domain.Configurations.Accounts;
using TailorWebApp.Domain.Configurations.Locations;
using TailorWebApp.Domain.Configurations.Orders;
using TailorWebApp.Domain.Configurations.Products;
using TailorWebApp.Domain.Configurations.Products.JoinEntities;
using TailorWebApp.Domain.Configurations.Staff;
using TailorWebApp.Domain.Configurations.NewsArticles;
using TailorWebApp.Domain.Entities.Accounts;
using TailorWebApp.Domain.Entities.Locations;
using TailorWebApp.Domain.Entities.NewsArticles;
using TailorWebApp.Domain.Entities.Orders;
using TailorWebApp.Domain.Entities.Products;
using TailorWebApp.Domain.Entities.Products.JoinEntities;
using TailorWebApp.Domain.Entities.StaffRelated;
using TailorWebApp.Utils.Constants;

namespace TailorWebApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUserAccount, IdentityRole, string,
            IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, AppUserTokens>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTagJoin> ProductTagsJoin { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<StaffSchedule> StaffSchedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OfferedService> OfferedServices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsStatus> NewsStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ProductCategoryConfiguration().Configure(modelBuilder.Entity<ProductCategory>());
            new ProductSizeConfiguration().Configure(modelBuilder.Entity<ProductSize>());
            new ProductStatusConfiguration().Configure(modelBuilder.Entity<ProductStatus>());
            new ProductTagConfiguration().Configure(modelBuilder.Entity<ProductTag>());
            new ProductTypeConfiguration().Configure(modelBuilder.Entity<ProductType>());
            new ProductTagJoinConfiguration().Configure(modelBuilder.Entity<ProductTagJoin>());
            new LocationConfiguration().Configure(modelBuilder.Entity<Location>());
            new RegionConfiguration().Configure(modelBuilder.Entity<Region>());
            new StaffScheduleConfiguration().Configure(modelBuilder.Entity<StaffSchedule>());
            new AppointmentConfiguration().Configure(modelBuilder.Entity<Appointment>());
            new MeasurementsConfiguration().Configure(modelBuilder.Entity<Measurement>());
            new OfferedServiceConfiguration().Configure(modelBuilder.Entity<OfferedService>());
            new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
            new ServiceCategoriesConfiguration().Configure(modelBuilder.Entity<ServiceCategory>());
            new AppUserAccountConfiguration().Configure(modelBuilder.Entity<AppUserAccount>());
            new NewsConfiguration().Configure(modelBuilder.Entity<News>());
            new NewsStatusConfiguration().Configure(modelBuilder.Entity<NewsStatus>());

            AddDefaultEnums(modelBuilder);

            SeedRoles(modelBuilder);
            SeedAdministrators(modelBuilder);
        }

        private static void AddDefaultEnums(ModelBuilder modelBuilder)
        {
            AddProductSizes(modelBuilder);
            AddProductStatuses(modelBuilder);
            AddProductTypes(modelBuilder);
            AddProductCategories(modelBuilder);
            AddRegions(modelBuilder);
            AddServiceCategories(modelBuilder);
            AddNewsStatus(modelBuilder);
        }

        private static void AddProductSizes(ModelBuilder modelBuilder)
        {
            var xxs = new ProductSize { Id = 1, Name = "XXS", IsDeleted = false };
            var xs = new ProductSize { Id = 2, Name = "XS", IsDeleted = false };
            var s = new ProductSize { Id = 3, Name = "S", IsDeleted = false };
            var m = new ProductSize { Id = 4, Name = "M", IsDeleted = false };
            var l = new ProductSize { Id = 5, Name = "L", IsDeleted = false };
            var xl = new ProductSize { Id = 6, Name = "XL", IsDeleted = false };
            var xxl = new ProductSize { Id = 7, Name = "XXL", IsDeleted = false };
            var xxxl = new ProductSize { Id = 8, Name = "XXXL", IsDeleted = false };

            modelBuilder
                .Entity<ProductSize>()
                .HasData(xxs, xs, s, m, l, xl, xxl, xxxl);
        }

        private static void AddProductStatuses(ModelBuilder modelBuilder)
        {
            var available = new ProductStatus { Id = 1, Name = "AVAILABLE" };
            var outofstock = new ProductStatus { Id = 2, Name = "OUTOFSTOCK" };
            var reserved = new ProductStatus { Id = 3, Name = "RESERVED" };

            modelBuilder
                .Entity<ProductStatus>()
                .HasData(available, outofstock, reserved);
        }

        private static void AddProductCategories(ModelBuilder modelBuilder)
        {
            var suit = new ProductCategory { Id = 1, Name = "SUIT" };
            var vest = new ProductCategory { Id = 2, Name = "VEST" };
            var trouser = new ProductCategory { Id = 3, Name = "TROUSER" };
            var shirt = new ProductCategory { Id = 4, Name = "SHIRT" };
            var handkerchief = new ProductCategory { Id = 5, Name = "HANDKERCHIEF" };
            var tie = new ProductCategory { Id = 6, Name = "TIE" };
            var bowtie = new ProductCategory { Id = 7, Name = "BOWTIE" };

            modelBuilder
                .Entity<ProductCategory>()
                .HasData(suit, vest, trouser, shirt, handkerchief, tie, bowtie);
        }

        private static void AddProductTypes(ModelBuilder modelBuilder)
        {
            var classic = new ProductType { Id = 1, Name = "CLASSIC SUIT", ProductCategoryId = 1 };
            var dinner = new ProductType { Id = 2, Name = "DINNER SUIT", ProductCategoryId = 1 };
            var tails = new ProductType { Id = 3, Name = "TAILS SUIT", ProductCategoryId = 1 };
            var sport = new ProductType { Id = 4, Name = "SPORT SUIT", ProductCategoryId = 1 };
            var blaser = new ProductType { Id = 5, Name = "BLASER SUIT", ProductCategoryId = 1 };

            var singleBreasted = new ProductType { Id = 6, Name = "SINGLE BREASTED VEST", ProductCategoryId = 2 };
            var doubleBreasted = new ProductType { Id = 7, Name = "DOUBLE BREASTED VEST", ProductCategoryId = 2 };

            var bandana = new ProductType { Id = 8, Name = "BANDANA HANDKERCHIEF", ProductCategoryId = 5 };
            var pocketSquares = new ProductType { Id = 9, Name = "POCKETSQUARE HANDKERCHIEF", ProductCategoryId = 5 };
            var printed = new ProductType { Id = 10, Name = "PRINTED HANDKERCHIEF", ProductCategoryId = 5 };
            var casual = new ProductType { Id = 11, Name = "CASUAL HANDKERCHIEF", ProductCategoryId = 5 };
            var formal = new ProductType { Id = 12, Name = "FORMAL HANDKERCHIEF", ProductCategoryId = 5 };

            var slim = new ProductType { Id = 13, Name = "SLIM TROUSER", ProductCategoryId = 3 };
            var regular = new ProductType { Id = 14, Name = "REGULAR TROUSER", ProductCategoryId = 3 };
            var classicT = new ProductType { Id = 15, Name = "CLASSIC TROUSER", ProductCategoryId = 3 };

            var dress = new ProductType { Id = 16, Name = "DRESS SHIRT", ProductCategoryId = 4 };
            var dressC = new ProductType { Id = 17, Name = "CASUAL SHIRT", ProductCategoryId = 4 };

            var skinny = new ProductType { Id = 18, Name = "SKINNY TIE", ProductCategoryId = 6 };
            var standard = new ProductType { Id = 19, Name = "STANDARD TIE", ProductCategoryId = 6 };
            var wide = new ProductType { Id = 20, Name = "WIDE TIE", ProductCategoryId = 6 };

            var butterfly = new ProductType { Id = 21, Name = "BUTTERFLY BOWTIE", ProductCategoryId = 7 };
            var diamond = new ProductType { Id = 22, Name = "DIAMOND BOWTIE", ProductCategoryId = 7 };

            modelBuilder
                .Entity<ProductType>()
                .HasData(classic, dinner, tails, sport, blaser, singleBreasted,
                doubleBreasted, bandana, pocketSquares, printed, casual, formal,
                slim, regular, dress, skinny, standard, wide, butterfly, diamond,
                classicT, dressC);
        }

        private static void AddRegions(ModelBuilder modelBuilder)
        {
            var europe = new Region { Id = 1, Name = "Europe" };
            var americas = new Region { Id = 2, Name = "America" };
            var asia = new Region { Id = 3, Name = "Asia" };
            var middleEast = new Region { Id = 4, Name = "Middle East and Africa" };

            modelBuilder.Entity<Region>()
                .HasData(europe, americas, asia, middleEast);
        }

        private static void AddServiceCategories(ModelBuilder modelBuilder)
        {
            var Alterations = new ServiceCategory { Id = 1, CategoryName = "Alterations" };
            var Tailoring = new ServiceCategory { Id = 2, CategoryName = "Tailoring" };
            var Repairs = new ServiceCategory { Id = 3, CategoryName = "Repairs" };
            var DryCleaning = new ServiceCategory { Id = 4, CategoryName = "DryCleaning" };
            var Pressing = new ServiceCategory { Id = 5, CategoryName = "Pressing" };
            var Hemming = new ServiceCategory { Id = 6, CategoryName = "Hemming" };
            var ZipperReplacement = new ServiceCategory { Id = 7, CategoryName = "Zipper Replacement" };
            var ButtonReplacement = new ServiceCategory { Id = 8, CategoryName = "Button Replacement" };

            modelBuilder.Entity<ServiceCategory>()
                .HasData(Alterations, Tailoring, Repairs,
                        DryCleaning, Pressing, Hemming,
                        ZipperReplacement, ButtonReplacement);
        }

        private static void SeedAdministrators(ModelBuilder builder)
        {
            const string admin = "Admin";
            const string userName = "admin@admin.com";
            var passwordHasher = new PasswordHasher<AppUserAccount>();

            var adminAccount = new AppUserAccount
            {
                Id = Constants.ADMIN_ID,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = userName,
                FirstName = admin,
                LastName = admin,
                ProfilePicture = ""
            };

            adminAccount.PasswordHash = passwordHasher.HashPassword(adminAccount, "Admin123@");
            builder.Entity<AppUserAccount>().HasData(adminAccount);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = Constants.ADMIN_ROLE_ID,
                    UserId = Constants.ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = Constants.CONTENT_CREATOR_ROLE_ID,
                    UserId = Constants.ADMIN_ID
                });

            builder.Entity<AppUserTokens>().HasData(
                new AppUserTokens
                {
                    UserId = Constants.ADMIN_ID,
                    LoginProvider = "Bearer",
                    Name = "JWT",
                    Value = string.Empty,
                    RefreshToken = string.Empty
                });
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
           new IdentityRole
           {
               Id = Constants.ADMIN_ROLE_ID,
               Name = Constants.ADMIN_ROLE,
               NormalizedName = Constants.ADMIN_ROLE.ToUpper()
           },
            new IdentityRole
            {
                Id = Constants.CONTENT_CREATOR_ROLE_ID,
                Name = Constants.CONTENT_CREATOR_ROLE,
                NormalizedName = Constants.CONTENT_CREATOR_ROLE.ToUpper()
            },
            new IdentityRole
            {
                Id = Constants.STAFF_ID,
                Name = Constants.STAFF_ROLE,
                NormalizedName = Constants.STAFF_ROLE.ToUpper()
            }
            );
        }

        private static void AddNewsStatus(ModelBuilder builder)
        {
            var draft = new NewsStatus { Id = 1, Name = "draft" };
            var published = new NewsStatus { Id = 2, Name = "published" };

            builder.Entity<NewsStatus>().HasData(draft, published);
        }
    }
}