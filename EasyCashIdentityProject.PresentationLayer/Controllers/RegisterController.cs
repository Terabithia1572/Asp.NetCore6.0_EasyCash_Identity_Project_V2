using EasyCashIdentityProject.DTOLayer.DTOS.AppUserDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {

                    UserName = appUserRegisterDTO.Username,
                    CustomerName = appUserRegisterDTO.Name,
                    CustomerSurname= appUserRegisterDTO.Surname,
                    Email = appUserRegisterDTO.Email,
                    City="Van",
                    District="a",
                    ImageURL="null"

                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDTO.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
