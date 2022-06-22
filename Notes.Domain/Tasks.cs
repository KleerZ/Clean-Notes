namespace Notes.Domain;

public class Tasks
{
    public Guid Id { get; set;}
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime EditDate { get; set; }
    public bool isDeleted { get; set; }
    public bool isCompleted { get; set; }
    
    public List<SubTask> SubTasks { get; set; }
}
