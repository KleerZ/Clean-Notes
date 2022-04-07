using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Tasks.Queries.GetTaskList;

public class GetTaskListQueryHandler: IRequestHandler<GetTaskListQuery, TaskListVM>
{
    private readonly INotesDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTaskListQueryHandler(INotesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TaskListVM> Handle(GetTaskListQuery request,
        CancellationToken cancellationToken)
    {
        var taskQuery = await _dbContext.Tasks
            .Where(task => task.UserId == request.UserId)
            .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new TaskListVM {Task = taskQuery};
    }
}