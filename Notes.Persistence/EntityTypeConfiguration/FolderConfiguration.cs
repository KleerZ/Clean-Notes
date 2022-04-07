using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

public class FolderConfiguration: IEntityTypeConfiguration<Folder>
{
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
        builder.HasKey(folder => folder.Id);
        builder.HasIndex(folder => folder.Id).IsUnique();

        builder.HasMany(folder => folder.Notes)
            .WithOne(note => note.Folder).IsRequired(false);

        builder.Property(folder => folder.Name).IsRequired();
        builder.HasIndex(folder => folder.Name).IsUnique();
        builder.Property(folder => folder.Name).HasMaxLength(100);
    }
}