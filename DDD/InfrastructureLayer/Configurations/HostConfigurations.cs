using DomainLayer.HostAggregate;
using DomainLayer.HostAggregate.ValueObjects; 
using DomainLayer.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class HostConfigurations : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            ConfigHostTable(builder);
            ConfigHostDinnersTable(builder);
            ConfigHostMenusTable(builder);

        }

        private void ConfigHostTable(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Hosts");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => HostId.Create(value));

            builder.Property(p => p.FirstName)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .HasMaxLength(50);

            builder.Property(p => p.ProfileImage)
                .HasMaxLength(2083);

            builder.Property(p => p.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value));
        }

        private void ConfigHostDinnersTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(o => o.MenuIds, mr =>
            {
                mr.ToTable("HostMenuIds");

                mr.WithOwner().HasForeignKey("MenuId");

                mr.HasKey("Id", "MenuId");

                mr.Property(p => p.Value)
                    .HasColumnName("HostMenuId");
            });

            builder.Metadata
                .FindNavigation(nameof(Host.MenuIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigHostMenusTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(o => o.DinnerIds, mr =>
            {
                mr.ToTable("HostDinnerIds");

                mr.WithOwner().HasForeignKey("MenuId");

                mr.HasKey("Id", "MenuId");

                mr.Property(p => p.Value)
                    .HasColumnName("HostDinnerId");
            });

            builder.Metadata
                .FindNavigation(nameof(Host.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
