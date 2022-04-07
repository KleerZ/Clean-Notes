using MediatR;

namespace Notes.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommand: IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    
    public DateTime EditDate { get; set; }
    public Dictionary<string, string[]> TaskItems { get; set; }
}