using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Name).HasMaxLength(15);
        builder.Property(user => user.Password).HasMaxLength(8);
        builder.Property(user => user.PhoneNumber).HasMaxLength(16);
    }
}