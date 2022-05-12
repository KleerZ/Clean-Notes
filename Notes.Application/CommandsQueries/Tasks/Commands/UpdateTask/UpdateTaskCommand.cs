using MediatR;
using Notes.Domain;

namespace Notes.Application.CommandsQueries.Tasks.Commands.UpdateTask;

public class UpdateTaskCommand: IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public List<SubTask> SubTasks { get; set; }
}