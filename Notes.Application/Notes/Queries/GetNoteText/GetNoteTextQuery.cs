using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteTextQuery: IRequest<NoteTextVM>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}