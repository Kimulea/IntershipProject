using Bloomcoding.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloomcoding.Dal.EntityConfiguration
{
    public class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .ToTable("Groups");

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.Groups)
                .UsingEntity(x => x.ToTable("UserGoups"));
        }
    }
}
