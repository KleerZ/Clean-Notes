using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces;

public interface INotesDbContext
{
    DbSet<Note> Notes { get; set; }
    DbSet<Domain.Tasks> Tasks { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);    
}