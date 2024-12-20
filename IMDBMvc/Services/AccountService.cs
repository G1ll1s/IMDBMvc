using IMDBMvc.Models;
using IMDBMvc.Views.Account;
using Microsoft.AspNetCore.Identity;

namespace IMDBMvc.Services
{
    public class AccountService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        )
    {
        public async Task<string?> TryRegisterAsync(RegisterVM viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Username,
                Email = viewModel.Email
            };

            IdentityResult result = await 
                userManager.CreateAsync(user, viewModel.Password);

            bool wasUserCreated = result.Succeeded;

            return wasUserCreated ? null : result.Errors.First().Description;
        }

        public async Task<string?> TryLoginAsync(LoginVM viewModel)
        {
            SignInResult result = await signInManager.PasswordSignInAsync(
                viewModel.Username,
                viewModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            bool wasUserSignedIn = result.Succeeded;

            return wasUserSignedIn ? null : "Invalid username or password";
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();

        }

    }
}
