using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Commands.CreateFolder;

public class CreateFolderCommandHandler: IRequestHandler<CreateFolderCommand, Guid>
{
    private readonly INotesDbContext _dbContext;

    public CreateFolderCommandHandler(INotesDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateFolderCommand request,
        CancellationToken cancellationToken)
    {
        var folder = new Folder
        {
            UserId = request.UserId,
            Name = request.Name
        };

        await _dbContext.Folders.AddAsync(folder, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return folder.Id;
    }
}