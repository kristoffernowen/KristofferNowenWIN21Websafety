using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSafeExam1.Models;

namespace WebSafeExam1.Controllers
{
    public class AccountController : Controller
    {

        public async Task Login(string returnUrl ="/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl).Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);


        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be added to the
                // **Allowed Logout URLs** settings for the app.
                // .WithRedirectUri(Url.Action("Index", "Home"))
                .WithRedirectUri("https://localhost:7298/")
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public IActionResult Testing()
        {
            return RedirectToAction("Index", "BlogEntities");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var didi = User.Identity.IsAuthenticated;

            return View(new UserProfile
            {
                EmailAddress = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                Name = User.Identity.Name,
                ProfileImage = User.Claims.FirstOrDefault(claim => claim.Type == "picture")?.Value
            });
        }
    }
}
