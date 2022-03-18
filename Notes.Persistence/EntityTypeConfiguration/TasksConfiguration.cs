using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

public class TasksConfiguration: IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.HasKey(task => task.Id);
        builder.HasIndex(task => task.Id).IsUnique();
        builder.Property(task => task.Title).HasMaxLength(100);
    }
}