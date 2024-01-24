using Crispy_Goggles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using FormEncode.Models;

namespace Crispy_Goggles.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ILogger<SecurityController> _logger;

        public SecurityController(ILogger<SecurityController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult IndexAuthenticated()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LoginAttempt")]
        
        public ViewResult LoginAttempt(LoginModel model)
        {
            if (model.username == "bing" && model.password == "test01")
            {
                return View("IndexAuthenticated");
            }
            else
            {
                return View("Login");
            }
        }


    }
}