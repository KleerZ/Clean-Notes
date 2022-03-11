using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfiguration;

namespace Notes.Persistence;

public class NoteDbContext: DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }

    public NoteDbContext(DbContextOptions<NoteDbContext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new NoteConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(builder);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}