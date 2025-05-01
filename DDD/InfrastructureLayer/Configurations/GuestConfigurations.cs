using DomainLayer.GuestAggregate;
using DomainLayer.GuestAggregate.ValueObjects; 
using DomainLayer.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configurations
{
    public class GuestConfigurations : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            ConfigGuestTable(builder);
            ConfigGuestUpCommingDinnersTable(builder);
            ConfigGuestPastCommingDinnersTable(builder);
            ConfigGuestPendingCommingDinnersTable(builder);
            ConfigGuestBillsTable(builder);
            ConfigGuestMenuReviewsTable(builder);
            ConfigGuestRatingsTable(builder);
        }
        private void ConfigGuestTable(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");

            builder.HasKey("Id");

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => GuestId.Create(value));

            builder.OwnsOne(o => o.AverageRating);
              
            builder.Property(p => p.FirstName)
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .HasMaxLength(50);

            builder.Property(p => p.ProfileImage)
                .HasMaxLength(2083);

            builder.Property(p => p.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value)); 
        }

        private void ConfigGuestUpCommingDinnersTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.UpcomingDinnerIds, ud =>
            {
                ud.ToTable("UpcomingDinnerIds");

                ud.WithOwner().HasForeignKey("GuestId");

                ud.HasKey("Id");

                ud.Property(p => p.Value)
                    .HasColumnName("UpcomingDinnerId");
            });

            builder.Metadata
                .FindNavigation(nameof(Guest.UpcomingDinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigGuestRatingsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.RatingIds, r =>
            {
                r.ToTable("RatingIds");

                r.WithOwner().HasForeignKey("GuestId");

                r.HasKey("Id");

                r.Property(p => p.Value)
                    .HasColumnName("RatingId");
            });

            builder.Metadata
                .FindNavigation(nameof(Guest.RatingIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigGuestMenuReviewsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.MenuReviewIds, mr =>
            { 
                mr.ToTable("GuestMenuReviewIds");

                mr.WithOwner().HasForeignKey("GuestId");

                mr.HasKey("Id");

                mr.Property(p => p.Value)
                    .HasColumnName("GuestMenuReviewId");
            });

            builder.Metadata
                .FindNavigation(nameof(Guest.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigGuestBillsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.BillIds, bi =>
            {
                bi.ToTable("BillIds");

                bi.WithOwner().HasForeignKey("GuestId");

                bi.HasKey("Id");

                bi.Property(p => p.Value)
                    .HasColumnName("BillId"); 
            });

            builder.Metadata
                .FindNavigation(nameof(Guest.BillIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigGuestPendingCommingDinnersTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.PendingDinnerIds, di =>
            {
                di.ToTable("PendingDinnerIds");

                di.WithOwner().HasForeignKey("GuestId");

                di.HasKey("Id");

                di.Property(p => p.Value)
                    .HasColumnName("PendingDinnerId");
            }); 
            builder.Metadata
                .FindNavigation(nameof(Guest.PendingDinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigGuestPastCommingDinnersTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(o => o.PastDinnerIds, pd =>
            {
                pd.ToTable("PastDinnerIds");

                pd.WithOwner().HasForeignKey("GuestId");

                pd.HasKey("Id");

                pd.Property(p => p.Value)
                    .HasColumnName("PastDinnerId");
            });

            builder.Metadata
                .FindNavigation(nameof(Guest.PastDinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        } 
    }
}
