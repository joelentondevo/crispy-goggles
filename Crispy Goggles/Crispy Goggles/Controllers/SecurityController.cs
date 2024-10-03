using Crispy_Backend.BusinessObject;
using FormEncode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Web;
using System.Data;
using System.Reflection.PortableExecutable;
using Microsoft.Identity.Client;
using Crispy_Backend.EntityObjects;
using Newtonsoft.Json;


namespace Crispy_Goggles.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ILogger<SecurityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        UserBO userBO;

        public SecurityController(ILogger<SecurityController> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult IndexAuthenticated()
        {
            return View();
        }
        public IActionResult Index() 
        { 
            return View(); 
        } 

        [HttpPost]
        [ActionName("LoginAttempt")]

        public ViewResult LoginAttempt(LoginModel model)
        {
            if (new UserBO().UserExists ( model.username, model.password) == true)
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
                UserSessionEO user = new UserBO().GetUser(model.username, model.password);
                indexModel.User = user;
                indexModel.basketTotal = indexModel.Basket.CalculateTotal();
                string userSessionString = JsonConvert.SerializeObject(user);
                _contextAccessor.HttpContext.Session.SetString("SessionUser", userSessionString);               

                return View("./Views/Home/Index.cshtml", indexModel);
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