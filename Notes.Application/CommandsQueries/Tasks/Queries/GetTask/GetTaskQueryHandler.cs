using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.CommandsQueries.Tasks.Queries.GetTask;

public class GetTaskQueryHandler: IRequestHandler<GetTaskQuery, TaskVm>
{
    private readonly INotesDbContext _context;
    private readonly IMapper _mapper;

    public GetTaskQueryHandler(INotesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TaskVm> Handle(GetTaskQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Tasks
            .FirstOrDefaultAsync(task => 
                task.Id == request.Id, cancellationToken);

        if (entity is null)
        {
            if (_context.Tasks.Count() > 0)
            {
                if (request.Id == Guid.Empty)
                {
                    if (entity is null)
                        entity = new Domain.Tasks();
                }
                else
                    entity = await _context.Tasks
                        .Where(n => n.Id == request.Id)
                        .FirstOrDefaultAsync(cancellationToken);
            }
            else 
                entity = new Domain.Tasks();
        }

        // throw new NotFoundException(nameof(Note), request.Id);

        return _mapper.Map<TaskVm>(entity);
    }
}