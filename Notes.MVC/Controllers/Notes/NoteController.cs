using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNote;
using Notes.MVC.Models;
using Notes.MVC.Services;
using Word = Microsoft.Office.Interop.Word;

namespace Notes.MVC.Controllers.Notes;

public class NoteController: BaseController
{
    private readonly NoteService _noteService;
    private readonly FolderService _folderService;

    public NoteController(NoteService noteService, FolderService folderService)
    {
        _noteService = noteService;
        _folderService = folderService;
    }

    [HttpGet]
    public async Task<IActionResult> AddPage()
    {
        var folderList = await _folderService.GetList(UserId);
        
        var vm = new CombineNoteVmFolderListVm
        {
            NoteVm = new NoteVM(),
            FolderListVm = folderList
        };

        return PartialView("~/Views/Notes/_NoteAddingPartial.cshtml", vm);
    }

    [HttpGet]
    public async Task<IActionResult> EditPage(Guid id)
    {
        var note = await _noteService.Get(id, UserId);
        var folderList = await _folderService.GetList(UserId);

        if (!Request.IsAjaxRequest())
            return RedirectToAction("Index", "Home", new {id = id});

        var vm = new CombineNoteVmFolderListVm
        {
            NoteVm = note,
            FolderListVm = folderList
        };

        return PartialView("~/Views/Notes/_NoteEditPartial.cshtml", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CombineNoteVmFolderListVm vm)
    {
        await _noteService.Add(vm, UserId);
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _noteService.Delete(id, UserId);

        var notes = await _noteService.GetDeletedList(UserId);

        return PartialView("~/Views/Trash/_TrashPartial.cshtml", notes);
    }

    [HttpPost]
    public async Task<IActionResult> ToTrash(Guid id)
    {
        await _noteService.NoteToTrash(id);
        
        var vm = await _noteService.GetList(UserId);
        
        return PartialView("~/Views/Notes/_NotesPartial.cshtml", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CombineNoteVmFolderListVm vm)
    {
        await _noteService.Update(vm, UserId);
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var vm = await _noteService.GetList(UserId);

        return PartialView("~/Views/Notes/_NotesPartial.cshtml", vm);
    }

    [HttpGet]
    public IActionResult NoSelected()
    {
        return PartialView("~/Views/Notes/_NoSelectedEditPartial.cshtml");
    }

    [HttpPost]
    public async Task PrintDocument(Guid id)
    {
        var note = await _noteService.Get(id, UserId);
        
        var oWord = new Word.Application();
        var oDoc = oWord.Documents.Add("D:\\Projects\\Clean-Notes\\" +
                                       "Notes.MVC\\wwwroot\\templates\\note-template.docx");
        
        oDoc.Bookmarks["title"].Range.Text = note.Title;
        oDoc.Bookmarks["text"].Range.Text = note.Text;
        
        oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\note.docx");
        oDoc.Close();
    }
}