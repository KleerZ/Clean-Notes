using MediatR;
using Notes.Application.CommandsQueries.Notes.Commands.Restore;

namespace Notes.MVC.Services;

public class TrashService
{
    private readonly IMediator _mediator;

    public TrashService(IMediator mediator) =>
        _mediator = mediator;

    public async Task Restore(Guid id)
    {
        var query = new RestoreCommand
        {
            Id = id
        };

        await _mediator.Send(query);
    }
}