using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Application.Notes.Queries.GetNoteList;

namespace Notes.MVC.Models;

public class CombineNoteFolderViewModel
{
    public NoteVM NoteVm { get; set; }
    public FolderListVm FolderList { get; set; }
    public FolderViewModel Folder { get; set; }
    public List<NoteLookupDto> NoteList { get; set; }
}