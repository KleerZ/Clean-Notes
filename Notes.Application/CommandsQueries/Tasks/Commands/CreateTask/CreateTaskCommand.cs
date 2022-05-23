using MediatR;

namespace Notes.Application.CommandsQueries.Tasks.Commands.CreateTask;

public class CreateTaskCommand: IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
}