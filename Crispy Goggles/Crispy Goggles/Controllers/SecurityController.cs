using Crispy_Goggles.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using FormEncode.Models;
using Microsoft.Data.SqlClient;
using Azure.Identity;


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
            string queryString = "p_LoginData_f";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", model.username);
                command.Parameters.AddWithValue("@password", model.password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        return View("IndexAuthenticated");
                    }
                    else
                    {
                        return View("Login");
                    }
                }
                finally 
                {
                    reader.Close();
                }



            }

        }


    }
}