using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Notes.MVC.Models;
using Notes.MVC.Services;

namespace Notes.MVC.Controllers.Tasks;

public class TasksController: BaseController
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IActionResult> Index()
    {
        var listTasks = (await _taskService.GetList(UserId)).Task;

        return PartialView("_TasksPartial", listTasks);
    }

    public async Task<IActionResult> EditPage(Guid id)
    {
        var task = await _taskService.Get(id);
        var subTasks = await _taskService.GetSubTasks(id);

        if (!Request.IsAjaxRequest())
            return RedirectToAction("Index", "Home", new {id = id});

        var vm = new CombineTaskSubTasks
        {
            TaskVm = task,
            SubTasks = subTasks
        };

        return PartialView("~/Views/Tasks/_TaskEditPartial.cshtml", vm);
    }
}