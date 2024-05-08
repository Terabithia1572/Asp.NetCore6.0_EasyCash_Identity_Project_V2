using EasyCashIdentityProject.DTOLayer.DTOS.AppUserDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
                Random r = new();
                int code;
                code = r.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {

                    UserName = appUserRegisterDTO.Username,
                    CustomerName = appUserRegisterDTO.Name,
                    CustomerSurname = appUserRegisterDTO.Surname,
                    Email = appUserRegisterDTO.Email,
                    City = "Van",
                    District = "a",
                    ImageURL = "null",
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDTO.Password);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new();
                    MailboxAddress mailboxAddressFrom = new("EasyCash Admin","terabithia188@gmail.com");
                    MailboxAddress mailboxAddressTo = new("User",appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt İşlemini Gerçekleştirmek için onay kodunuz " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu: ";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com",587,false);
                    smtpClient.Authenticate("terabithia188@gmail.com", "kogpwiapcmlpdprb​");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDTO.Email;



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
