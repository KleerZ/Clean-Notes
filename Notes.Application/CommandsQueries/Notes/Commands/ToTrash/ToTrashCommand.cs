using MediatR;

namespace Notes.Application.CommandsQueries.Notes.Commands.ToTrash;

public class ToTrashCommand: IRequest
{
    public Guid Id { get; set; }
}