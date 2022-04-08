using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.Application.CommandsQueries.Notes.Queries.GetNoteList;

public class GetNoteListQueryHandler: IRequestHandler<GetNoteListQuery, NoteListVm>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteListQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteListVm> Handle(GetNoteListQuery request,
        CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Notes
            .Where(note => note.UserId == request.UserId)
            .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(n => n.EditDate)
            .ToListAsync(cancellationToken);

        if (notesQuery == null)
            notesQuery = new List<NoteLookupDto>();

        return new NoteListVm {Notes = notesQuery};
    }
}