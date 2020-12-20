using System.Collections.Generic;
using System.Threading.Tasks;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace JobTrackingApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel entity)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName =  entity.UserName,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    SurName = entity.LastName
                };
                IdentityResult identityResult = await _userManager.CreateAsync(appUser, entity.Password);
                if (identityResult.Succeeded)
                {
                    IdentityResult addRoleIdentityResult =  await _userManager.AddToRoleAsync(appUser, "Member");
                    if (addRoleIdentityResult.Succeeded)
                    {
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        foreach (var identityResultError in identityResult.Errors)
                        {
                            ModelState.AddModelError("", identityResultError.Description);
                        }
                    }
                }
                else
                {
                    foreach (IdentityError identityResultError in identityResult.Errors)
                    {
                        ModelState.AddModelError("", identityResultError.Description);
                    }
                }
            }
            return View(entity);
        }

        public IActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel entity)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(entity.UserName);
                if (user != null)
                {
                   SignInResult signInResult =  await _signInManager.PasswordSignInAsync(user, entity.Password, entity.RememberMe, false);
                   if (signInResult.Succeeded)
                   {
                       IList<string> roles = await _userManager.GetRolesAsync(user);
                       if (roles.Contains("Admin"))
                       {
                           return RedirectToAction("Index", "Home", new {area = "Admin"});
                       } else if (roles.Contains("Member"))
                       {
                           return RedirectToAction("Index", "Home", new {area = "Member"});
                       }
                   }
                   else
                   {
                       ModelState.AddModelError("", "Kullanıcı adı veya parolanız yanlış! Lütfen bilgileri doğru girdiğinize emin olun.");
                   }
                }
                else
                {
                    ModelState.AddModelError(nameof(entity.UserName), "Böyle bir kullanıcı bulunamadı!");
                }
            }
            return View(entity);
        }
    }
}