using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;

public class GetFolderListQueryHandler: IRequestHandler<GetFolderListQuery, FolderListVm>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetFolderListQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<FolderListVm> Handle(GetFolderListQuery request,
        CancellationToken cancellationToken)
    {
        var folderQuery = await _dbContext.Folders
            .Where(folder => folder.UserId == request.UserId)
            .ProjectTo<FolderLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        if (folderQuery == null)
            folderQuery = new List<FolderLookupDto>();

        return new FolderListVm {Folders = folderQuery};
    }
}