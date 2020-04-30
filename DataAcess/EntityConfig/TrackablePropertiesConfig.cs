using Core.BaseTypes;
using Core.Interfaces.Types;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityConfig
{
    internal static class TrackablePropertiesConfig
    {
        internal static void ConfigureTrackable<T>(this ModelBuilder modelBuilder) where T : class, ITrackable
        {
            modelBuilder.Entity<T>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}