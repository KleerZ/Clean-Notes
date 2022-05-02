using MediatR;

namespace Notes.Application.CommandsQueries.Notes.Commands.Restore;

public class RestoreCommand: IRequest
{
    public Guid Id { get; set; }
}