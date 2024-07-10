using Crispy_Backend.BusinessObject;
using FormEncode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


namespace Crispy_Goggles.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IConfiguration _configuration;
        UserBO userBO;

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
            if (new UserBO().UserExists ( model.username, model.password) == true)
            {
                return View("Index");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpPost]
        [ActionName("RegisterAttempt")]

        public bool RegisterAttempt(LoginModel model)
        {
            return new UserBO().AddNewUser(model.username, model.password);
        }
    }
}