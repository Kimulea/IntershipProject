using Bloomcoding.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.EntityConfiguration
{
    public class HomeworkConfig : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .ToTable("Homeworks");

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.Homeworks)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
