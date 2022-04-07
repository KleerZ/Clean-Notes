using MediatR;

namespace Notes.Application.Tasks.Queries.GetTaskList;

public class GetTaskListQuery: IRequest<TaskListVM>
{
    public Guid UserId { get; set; }
}