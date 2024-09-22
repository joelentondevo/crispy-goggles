using Crispy_Backend.BusinessObject;
using FormEncode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using Crispy_Goggles.Models;
using System.Diagnostics;
using Crispy_Backend.EntityObjects;

namespace Crispy_Goggles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.ProductSet = new ProductBO().GetFullProductList();
            return View(indexModel);
        }

        public IActionResult IndexAuthenticated()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.ProductSet = new ProductBO().GetFullProductList();
            return View(indexModel);
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

        [HttpPost]
        [ActionName("BasketAdd")]

        public ViewResult BasketAdd(BasketModel model)
        {
            
            return View();
        }

        [HttpPost]
        [ActionName("BasketRemove")]

        public ViewResult BasketRemove(BasketModel model)
        {
            return null;
        }
    }
}
