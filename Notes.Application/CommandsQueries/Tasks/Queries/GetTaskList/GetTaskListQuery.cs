using MediatR;

namespace Notes.Application.CommandsQueries.Tasks.Queries.GetTaskList;

public class GetTaskListQuery: IRequest<TaskListVM>
{
    public Guid UserId { get; set; }
}