using DomainLayer.BillAggregate.ValueObjects;
using DomainLayer.DinnerAggregate;
using DomainLayer.DinnerAggregate.ValueObjects;
using DomainLayer.GuestAggregate.ValueObjects;
using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate.ValueObjects; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigDinnerTable(builder);
            ConfigDinnerReservationsTable(builder);
        }

        private void ConfigDinnerTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.ToTable("Dinners");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => DinnerId.Create(value));

            builder.OwnsOne(o => o.Price);

            builder.OwnsOne(o => o.Location);

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(100);

            builder.Property(p => p.HostId)
                .HasConversion(id => id.Value, value => HostId.Create(value));

            builder.Property(p => p.MenuId)
                .HasConversion(id => id.Value, value => MenuId.Create(value));
        }

        private void ConfigDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(o => o.ReservationIds, dr =>
            {
                dr.ToTable("Reservations");

                dr.WithOwner().HasForeignKey("DinnerId");

                dr.HasKey("Id", "DinnerId");

                dr.Property(p => p.Id)
                    .HasConversion(
                        id => id.Value,
                        value => ReservationId.Create(value))
                    .HasColumnName("ReservationId");

                dr.Property(p => p.GuestId)
                    .HasConversion(id => id.Value, value => GuestId.Create(value));

                dr.Property(p => p.BillId)
                    .HasConversion(id => id.Value, value => BillId.Create(value));
            });

            builder.Metadata
                .FindNavigation(nameof(Dinner.ReservationIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
         
    }
}
