namespace Notes.Domain;

public class Note
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public bool isDeleted { get; set; }
    public DateTime? EditDate { get; set; }
    public Folder Folder { get; set; }
    public Guid? FolderId { get; set; }
}