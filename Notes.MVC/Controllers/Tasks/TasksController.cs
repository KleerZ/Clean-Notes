using Microsoft.AspNetCore.Mvc;

namespace Notes.MVC.Controllers.Tasks;

public class TasksController: BaseController
{
    public IActionResult Index()
    {
        return PartialView("_TasksPartial");
    }
}