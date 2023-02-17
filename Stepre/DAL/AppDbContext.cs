using Microsoft.EntityFrameworkCore;
using Stepre.Models.Entities;

namespace Stepre.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MainLogo> MainLogos { get; set; }
        public DbSet<FreeShippingValue> FreeShippingValues { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public DbSet<ShippingInformation> ShippingInformations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SupportedPayment> SupportedPayments { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<DestinationCity> DestinationCities { get; set; }
        public DbSet<DestinationCountry> DestinationCountries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
