namespace Notes.Domain;

public class SubTask
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool isChecked { get; set; }
    
    public Task Task { get; set; }
}