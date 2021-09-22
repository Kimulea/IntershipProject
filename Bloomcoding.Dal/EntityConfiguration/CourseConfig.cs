using Bloomcoding.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloomcoding.Dal.EntityConfiguration
{
    class CourseConfig : IEntityTypeConfiguration<Course>
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
                .HasMany(x => x.Groups)
                .WithMany(x => x.Courses)
                .UsingEntity(x => x.ToTable("GroupCourses"));
        }
    }
}
