using FinalExam.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.DAL.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Departments>
{
    public void Configure(EntityTypeBuilder<Departments> builder)
    {
        builder.HasIndex(x => x.Title);
        builder.Property(x => x.Title).HasMaxLength(128);
    }
}
