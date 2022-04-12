using Notes.Application.CommandsQueries.Folders.Queries.GetFolder;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.MVC.Models;

public class CombineNoteLookupFolder
{
    public List<NoteLookupDto>? NoteLookupDto { get; set; }
    public FolderVM? FolderVm { get; set; }
}