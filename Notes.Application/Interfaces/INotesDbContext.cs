using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces;

public interface INotesDbContext
{
    DbSet<Note> Notes { get; set; }
    DbSet<Domain.Tasks> Tasks { get; set; }
    DbSet<SubTask> SubTasks{ get; set; }
    DbSet<Folder> Folders { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);    
}