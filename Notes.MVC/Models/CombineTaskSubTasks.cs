using Notes.Application.CommandsQueries.Tasks.Queries.GetTask;
using Notes.Domain;

namespace Notes.MVC.Models;

public class CombineTaskSubTasks
{
    public TaskVm? TaskVm { get; set; }
    public List<SubTask>? SubTasks { get; set; }
    public string? TaskTitle { get; set; }
}