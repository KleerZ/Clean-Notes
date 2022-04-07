using MediatR;

namespace Notes.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Dictionary<string, string[]> TaskItems { get; set; }
    public DateTime EditDate { get; set; }
}