using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

public class TasksConfiguration: IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.HasKey(tasks => tasks.Id);
        builder.HasIndex(tasks => tasks.Id).IsUnique();
        
        builder.Property(tasks => tasks.Title).HasMaxLength(100);
    }
}