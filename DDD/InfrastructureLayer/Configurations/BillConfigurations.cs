using DomainLayer.BillAggregate;
using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects; 
using DomainLayer.HostAggregate.ValueObjects;  
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            ConfigBillTable(builder);  
        }

        private void ConfigBillTable(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => BillId.Create(value));
                
            builder.Property(p => p.DinnerId)
                .HasConversion(id => id.Value, value => DinnerId.Create(value));

            builder.Property(p => p.GuestId)
               .HasConversion(id => id.Value, value => GuestId.Create(value));

            builder.Property(p => p.HostId)
               .HasConversion(id => id.Value, value => HostId.Create(value));
             
            builder.OwnsOne(o => o.Price);
        } 
    }
}
