namespace Notes.Domain;

public class SubTask
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool isChecked { get; set; }
    public DateTime CreateDate { get; set; }
    
    public Tasks Tasks { get; set; }
}