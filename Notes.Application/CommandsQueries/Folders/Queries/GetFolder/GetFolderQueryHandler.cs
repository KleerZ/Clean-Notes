using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolder;

public class GetFolderQueryHandler : IRequestHandler<GetFolderQuery, FolderVM>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetFolderQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<FolderVM> Handle(GetFolderQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Folders
            .FirstOrDefaultAsync(folder =>
                folder.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            if (_dbContext.Folders.Any())
            {
                entity = await _dbContext.Folders
                    .Where(n => n.UserId == request.UserId
                                && n.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
            }
            else
            {
                entity = new Folder();
            }
        }

        return _mapper.Map<FolderVM>(entity);
    }
}