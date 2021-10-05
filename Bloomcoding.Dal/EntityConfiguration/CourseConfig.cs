using Bloomcoding.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloomcoding.Dal.EntityConfiguration
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .ToTable("Courses");

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.GroupId);
        }
    }
}
