using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace TasklySolution.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ITaskService _taskService;

        public HomeController(ITaskService taskService
            , IAccountService accountService)
        {
            _taskService = taskService;
            _accountService = accountService;   
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var aboutMe = await _accountService.GetCurrentUser(userId);
            return View(aboutMe);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
