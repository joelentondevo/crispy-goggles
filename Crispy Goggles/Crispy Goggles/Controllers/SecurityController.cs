using Crispy_Goggles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using FormEncode.Models;

namespace Crispy_Goggles.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SecurityController> _logger;
        public SecurityController(ILogger<SecurityController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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
            string connectionString = _configuration.GetConnectionString("Backend");
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