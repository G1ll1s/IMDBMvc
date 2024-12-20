using IMDBMvc.Services;
using IMDBMvc.Views.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IMDBMvc.Controllers
{
    public class AccountController(
        AccountService _accountService, 
        StateService _stateService
        ): Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var errorMessage = await _accountService.TryRegisterAsync(model);
            if (errorMessage != null)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var errorMessage = await _accountService.TryLoginAsync(viewModel);
            if (errorMessage != null)
            {
                ModelState.AddModelError(string.Empty, errorMessage);
                return View();
            }

            _stateService.Message = "You are now logged in!";
            return RedirectToAction(nameof(MovieController.Index),"Movie");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
