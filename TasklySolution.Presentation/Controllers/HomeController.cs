using BusinessLogic.Contracts;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TasklySolution.Presentation.Models;


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
            string? userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var viewModel = new HomeViewModel
            {
                User = await _accountService.GetCurrentUser(userId),
                UserStats = await _accountService.GetUserStats(userId)
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
