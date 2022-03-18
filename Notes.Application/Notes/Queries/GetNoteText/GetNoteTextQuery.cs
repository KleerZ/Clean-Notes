using MediatR;
using Notes.Application.Notes.Queries.GetNoteDetails;

namespace Notes.Application.Notes.Queries.GetNoteText;

public class GetNoteTextQuery: IRequest<NoteTextVM>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}