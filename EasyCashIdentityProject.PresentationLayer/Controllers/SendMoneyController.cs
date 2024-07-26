using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DTOLayer.DTOS.CustomerAccountProcessDTOs;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber ==
            sendMoneyForCustomerAccountProcessDTO.ReceiverAccountNumber).Select(y => y.CustomerAccountID)
            .FirstOrDefault();
            //sendMoneyForCustomerAccountProcessDTO.SenderID = user.Id;
            //sendMoneyForCustomerAccountProcessDTO.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcessDTO.ProcessType = "Havale";
            //sendMoneyForCustomerAccountProcessDTO.ReceiverID = receiverAccountNumberID;

            var values = new CustomerAccountProccess();
            values.ProcessDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID= user.Id;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDTO.Amount;

            _customerAccountProcessService.TInsert(values);
            return RedirectToAction("Index", "Deneme");
        }
    }
}
