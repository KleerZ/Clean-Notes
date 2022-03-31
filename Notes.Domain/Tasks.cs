namespace Notes.Domain;

public class Tasks
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime EditDate { get; set; }
}
