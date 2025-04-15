using BusinessLogic.Contracts;
using BusinessLogic.DTOs.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TasklySolution.Presentation.Models;

namespace TasklySolution.Presentation.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ITagService _tagService;
        private readonly IPriorityService _priorityService;
        private readonly IQuotesService _quotesService;

        public TasksController(ITaskService taskService
                , ITagService tagService
                , IPriorityService priorityService
                , IQuotesService quotesService)
        {
            _taskService = taskService;
            _tagService = tagService;
            _priorityService = priorityService;
            _quotesService = quotesService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var tasks = await _taskService.GetUserTasks(userId);
            var tags = await _tagService.GetTags(userId);
            var quotes = await _quotesService.GetQuotes();

            var taksViewModel = new TasksPanelViewModel
            {
                UserName = User?.Identity?.Name,
                Tasks = tasks,
                Tags = tags,
                Quotes = quotes
            };

            return View(taksViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Task(Guid id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound();

            return View(task);
        }
        
        [HttpPost("Complete/{id}")]
        public async Task<IActionResult> CompleteTask(Guid id)
        {
            await _taskService.ExecuteTask(id);
            TempData["success"] = "congratulation";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var tags = await _tagService.GetTags(userId);
            var priorities = await _priorityService.GetPriorities();

            var viewModel = new AddTaskViewModel
            {
                Tags = tags,
                Priorities = priorities
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskAddDTO task)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Invalid data";
                return BadRequest(ModelState);
            }

            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _taskService.AddTask(task, userId);

            TempData["success"] = "added successfully";

            return RedirectToAction("Index");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _taskService.DeleteTask(id);
            TempData["success"] = "deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
