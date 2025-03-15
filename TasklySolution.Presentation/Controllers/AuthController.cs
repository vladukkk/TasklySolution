using BusinessLogic.Contracts;
using BusinessLogic.DTOs.User.Auth;
using Microsoft.AspNetCore.Mvc;

namespace TasklySolution.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            TempData["SuccessMessage"] = "Registration successful! Please log in.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var result = await _authService.LoginAsync(model);
            if(!result.Succeeded)
                return Unauthorized(new { Message = "Invalid credentials" });
            
            if(result.IsNotAllowed)
                return BadRequest(new { Message = "Email is not confirmed" });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}
