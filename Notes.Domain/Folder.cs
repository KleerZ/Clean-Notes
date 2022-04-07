namespace Notes.Domain;

public class Folder
{
    public Guid Id { get; set;}
    public Guid UserId { get; set;}
    public string Name { get; set;}
    public List<Note> Notes { get; set; }
}