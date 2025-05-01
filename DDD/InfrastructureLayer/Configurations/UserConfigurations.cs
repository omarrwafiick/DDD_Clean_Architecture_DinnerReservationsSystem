using DomainLayer.BillAggregate;
using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects; 
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.UserAggregate;
using DomainLayer.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigUserTable(builder);  
        }

        private void ConfigUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => UserId.Create(value));
        } 
    }
}
