using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.CommandsQueries.Tasks.Queries.GetTask;
using Notes.Application.CommandsQueries.Tasks.Queries.GetTaskList;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.MVC.Services;

public class TaskService
{
    private readonly IMediator _mediator;
    private readonly INotesDbContext _context;

    public TaskService(IMediator mediator, INotesDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    public async Task<TaskListVM> GetList(Guid userId)
    {
        var query = new GetTaskListQuery
        {
            UserId = userId
        };

        var list = await _mediator.Send(query);

        return list;
    }

    public async Task<TaskVm> Get(Guid id)
    {
        var query = new GetTaskQuery
        {
            Id = id
        };
        
        var task = await _mediator.Send(query);

        return task;
    }

    public async Task<List<SubTask>> GetSubTasks(Guid id)
    {
        var subTasks = await _context.SubTasks
            .Where(s => s.Tasks.Id == id)
            .ToListAsync();

        return subTasks;
    }
}