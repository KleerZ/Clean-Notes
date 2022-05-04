using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Notes.Queries.GetNote;

public class GetNoteQueryHandler: IRequestHandler<GetNoteQuery, NoteVM>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteVM> Handle(GetNoteQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Notes
            .FirstOrDefaultAsync(note => 
                note.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            if (_dbContext.Notes.Count() > 0)
            {
                if (request.Id == Guid.Empty)
                {
                    // entity = _dbContext.Notes.Where(n => n.UserId == request.UserId)
                    //     .OrderBy(n => n.EditDate)
                    //     .Last();

                    if (entity is null)
                        entity = new Note();
                }
                else
                    entity = await _dbContext.Notes.Where(n => n.UserId == request.UserId).FirstOrDefaultAsync();
            }
            else 
                entity = new Note();
        }

        // throw new NotFoundException(nameof(Note), request.Id);

        return _mapper.Map<NoteVM>(entity);
    }
}