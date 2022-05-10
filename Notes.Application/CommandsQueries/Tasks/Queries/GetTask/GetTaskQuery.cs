using MediatR;

namespace Notes.Application.CommandsQueries.Tasks.Queries.GetTask;

public class GetTaskQuery: IRequest<TaskVm>
{
    public Guid Id { get; set; }
}