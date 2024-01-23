using Microsoft.AspNetCore.Mvc;

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
    }
}
