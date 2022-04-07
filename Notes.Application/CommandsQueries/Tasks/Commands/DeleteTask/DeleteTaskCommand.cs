using MediatR;

namespace Notes.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskCommand: IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}