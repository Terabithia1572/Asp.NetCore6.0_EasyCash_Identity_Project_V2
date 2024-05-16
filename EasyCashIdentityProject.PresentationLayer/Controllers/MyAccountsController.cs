using EasyCashIdentityProject.DTOLayer.DTOS.AppUserDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDTO appUserEditDTO = new();
            appUserEditDTO.Name = values.CustomerName;
            appUserEditDTO.Surname = values.CustomerSurname;
            appUserEditDTO.ImageURL = values.ImageURL;
            appUserEditDTO.PhoneNumber=values.PhoneNumber; 
            appUserEditDTO.District= values.District;
            appUserEditDTO.City= values.City;
            appUserEditDTO.EMail = values.Email;

            return View(appUserEditDTO);
        }
        //[HttpPost]
    }
}
