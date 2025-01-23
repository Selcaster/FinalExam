using FinalExam.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.DAL.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Doctors>
{
    public void Configure(EntityTypeBuilder<Doctors> builder)
    {
        builder.HasIndex(x => x.Name);
        builder.Property(x => x.Name).HasMaxLength(32);
    }
}
