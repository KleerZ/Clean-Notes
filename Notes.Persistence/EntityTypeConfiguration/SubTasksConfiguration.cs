using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

public class SubTasksConfiguration: IEntityTypeConfiguration<SubTask>
{
    public void Configure(EntityTypeBuilder<SubTask> builder)
    {
        builder.HasKey(subTask => subTask.Id);
        builder.HasIndex(subTask => subTask.Id).IsUnique();
        builder.Property(subTask => subTask.Text).HasMaxLength(100);
    }
}