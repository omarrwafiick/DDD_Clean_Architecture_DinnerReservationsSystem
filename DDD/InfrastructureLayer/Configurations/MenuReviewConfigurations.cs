using DomainLayer.BillAggregate;
using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects; 
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects;
using DomainLayer.MenuReviewAggregate;
using DomainLayer.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
    {
        public void Configure(EntityTypeBuilder<MenuReview> builder)
        {
            ConfigMenuReviewTable(builder);  
        }

        private void ConfigMenuReviewTable(EntityTypeBuilder<MenuReview> builder)
        {
            builder.ToTable("MenuReviews");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => MenuReviewId.Create(value));
                
            builder.Property(p => p.DinnerId)
                .HasConversion(id => id.Value, value => DinnerId.Create(value));

            builder.Property(p => p.GuestId)
               .HasConversion(id => id.Value, value => GuestId.Create(value));

            builder.Property(p => p.HostId)
               .HasConversion(id => id.Value, value => HostId.Create(value));
            
            builder.Property(p => p.MenuId)
               .HasConversion(id => id.Value, value => MenuId.Create(value));

            builder.Property(p => p.Comment)
                .HasMaxLength(500);
        } 
    }
}
