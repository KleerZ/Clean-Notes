using Notes.Application.CommandsQueries.Folders.Queries.GetFolderList;
using Notes.Application.Notes.Queries.GetNote;
using Notes.Domain;

namespace Notes.MVC.Models;

public class CombineNoteVmFolderListVm
{
    public NoteVM? NoteVm { get; set; }
    public FolderListVm? FolderListVm { get; set; }
}