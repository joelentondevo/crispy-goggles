using Crispy_Backend.BusinessObject;
using FormEncode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
using Crispy_Goggles.Models;
using System.Diagnostics;
using Crispy_Backend.EntityObjects;
using Newtonsoft.Json;

namespace Crispy_Goggles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.ProductSet = new ProductBO().GetFullProductList();
            if (_contextAccessor.HttpContext.Session.GetString("basket") == null)
            {
                indexModel.Basket = new BasketEO(); 
            }
            else
            {
                indexModel.Basket = JsonConvert.DeserializeObject<BasketEO>(_contextAccessor.HttpContext.Session.GetString("basket"));
            }
            if (_contextAccessor.HttpContext.Session.GetString("SessionUser") != null)
            {
                indexModel.User = JsonConvert.DeserializeObject<UserSessionEO>(_contextAccessor.HttpContext.Session.GetString("SessionUser"));
            }
            indexModel.basketTotal = indexModel.Basket.CalculateTotal();
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
        [ActionName("AddItemToBasket")]

        public IActionResult BasketAdd(BasketModel model)
        {
            IndexModel indexModel = new IndexModel();
            BasketBO Baskethandler = new BasketBO();
            UserSessionEO user = new UserSessionEO();
            BasketEO basket = new BasketEO()
            {
                Items = new List<ProductInstanceEO>()
            }
            ;
            if (_contextAccessor.HttpContext.Session.GetString("basket") != null)
            { 
                basket = JsonConvert.DeserializeObject<BasketEO>(_contextAccessor.HttpContext.Session.GetString("basket"));
            }
            if (_contextAccessor.HttpContext.Session.GetString("SessionUser") != null)
            {
                user = JsonConvert.DeserializeObject<UserSessionEO>(_contextAccessor.HttpContext.Session.GetString("SessionUser"));
            }
                ProductRecordEO productToAdd = new ProductBO().GetProductByID(model.ProductId);
            Baskethandler.AddItemToBasket(basket, productToAdd, user);
            _contextAccessor.HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ActionName("RemoveItemFromBasket")]

        public IActionResult BasketRemove(BasketModel model)
        {
            IndexModel indexModel = new IndexModel();
            BasketBO Baskethandler = new BasketBO();
            UserSessionEO user = new UserSessionEO();
            BasketEO basket = new BasketEO()
            {
                Items = new List<ProductInstanceEO>()
            }
            ;
            if (_contextAccessor.HttpContext.Session.GetString("basket") != null)
            {
                basket = JsonConvert.DeserializeObject<BasketEO>(_contextAccessor.HttpContext.Session.GetString("basket"));
            }
            if (_contextAccessor.HttpContext.Session.GetString("SessionUser") != null)
            {
                user = JsonConvert.DeserializeObject<UserSessionEO>(_contextAccessor.HttpContext.Session.GetString("SessionUser"));
            }
            ProductRecordEO productToRemove = new ProductBO().GetProductByID(model.ProductId);
            Baskethandler.RemoveItemFromBasket(basket, productToRemove, user);
            _contextAccessor.HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction("Index", "Home");
        }
    }
}
