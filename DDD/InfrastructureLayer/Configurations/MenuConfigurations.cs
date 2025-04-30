using DomainLayer.HostAggregate.ValueObjects;
using DomainLayer.MenuAggregate; 
using DomainLayer.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigMenuTable(builder);
            ConfigMenuEntitiesTable(builder);
            ConfigMenuReviewsIdsTable(builder);
            ConfigMenuDinnerIdsTable(builder);
        }

        private void ConfigMenuTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey("Id");

            builder.Property(p => p.Id) 
                .HasConversion(id => id.Value, value => MenuId.Create(value));

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(100);
            //table sharing by 2 entities
            builder.OwnsOne(o => o.AverageRating);

            builder.Property(p => p.HostId) 
                .HasConversion(id => id.Value, value => HostId.Create(value));
        }

        private void ConfigMenuEntitiesTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(o => o.MenuSections, ms =>
            {
                ms.ToTable("MenuSections");

                ms.WithOwner().HasForeignKey("MenuId");

                ms.HasKey("Id", "MenuId");

                ms.Property(p => p.Id) 
                    .HasConversion(
                        id => id.Value, 
                        value => MenuSectionId.Create(value)) 
                    .HasColumnName("MenuSectionId"); 

                ms.Property(p => p.Name)
                    .HasMaxLength(100);

                ms.Property(p => p.Description)
                    .HasMaxLength(100);

                ms.OwnsMany(o => o.MenuItems, mi =>
                {
                    mi.ToTable("MenuItems");

                    mi.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    mi.HasKey("Id", "MenuSectionId", "MenuId");

                    mi.Property(p => p.Id) 
                        .HasConversion(id => id.Value, value => MenuItemId.Create(value)) 
                        .HasColumnName("MenuItemId");

                    mi.Property(p => p.Name)
                        .HasMaxLength(100);

                    mi.Property(p => p.Description)
                        .HasMaxLength(100);
                });

                ms.Navigation(i => i.MenuItems).Metadata.SetField("_menuItems");
                ms.Navigation(i => i.MenuItems).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuSections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigMenuReviewsIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(o => o.MenuReviewIds, mr =>
            {
                mr.ToTable("MenuReviewIds");

                mr.WithOwner().HasForeignKey("MenuId");

                mr.HasKey("Id");

                mr.Property(p => p.Value)  
                    .HasColumnName("MenuReviewId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);  

        }

        private void ConfigMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        { 
            builder.OwnsMany(o => o.DinnerIds, di =>
            {
                di.ToTable("MenuDinnerIds");

                di.WithOwner().HasForeignKey("MenuId");

                di.HasKey("Id");

                di.Property(p => p.Value) 
                    .HasColumnName("DinnerId");
            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field); 

        }
    }
}
