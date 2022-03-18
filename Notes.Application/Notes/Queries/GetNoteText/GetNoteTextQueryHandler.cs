using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteText;

public class GetNoteTextQueryHandler: IRequestHandler<GetNoteTextQuery, NoteTextVM>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteTextQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteTextVM> Handle(GetNoteTextQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes
            .FirstOrDefaultAsync(note => 
                note.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Note), request.Id);

        return _mapper.Map<NoteTextVM>(entity);
    }
}