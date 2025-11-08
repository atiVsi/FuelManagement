using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using FuelManagement.Core.Services.Interface;
using FuelManagement.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FuelManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IUserService _userService;
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger,IUserService userService)
        //{
        //    _logger = logger;
        //    _userService = userService;
   

        //}
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return Redirect("/home/main");
        }









        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult Main()
        {

            ViewBag.ProposalCallCount = 13;   // تعداد فراخوان‌ها
            ViewBag.ProposalCount = 244;
            //ViewBag.ProposalPublic = _proposalService.GetProposalCountpublic();
            //ViewBag.ProposalEmployee = _proposalService.GetProposalCountEmployee();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
