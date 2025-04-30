using DomainLayer.BillAggregate;
using DomainLayer.Common.BaseClasses;
using DomainLayer.DinnerAggregate;
using DomainLayer.GuestAggregate;
using DomainLayer.HostAggregate;
using DomainLayer.MenuAggregate;
using DomainLayer.MenuReviewAggregate;
using DomainLayer.UserAggregate;
using InfrastructureLayer.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
 
namespace InfrastructureLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly PublishDomainEventInterceptors _interceptor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, PublishDomainEventInterceptors interceptor) : base(options) {
            _interceptor = interceptor;
        }
         
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<MenuReview> MenuReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Host> Hosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.IsPrimaryKey())
                .ToList()
                .ForEach(k => k.ValueGenerated = ValueGenerated.Never);

            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
