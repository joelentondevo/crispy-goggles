using FormEncode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;


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

            DataSet queryResult = RunSP_DS(queryString,
                ("@username", model.username),
                ("@password", model.password));

            if (queryResult.Tables.Count != 0 && queryResult.Tables[0].Rows.Count != 0 )
            {
                return View("IndexAuthenticated");
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
            string connectionString = _configuration.GetConnectionString("Backend");
            string queryString = "p_RegisterUser_f";

            return RUNSP_Bool(queryString,
                ("@username", model.username),
                ("@password", model.password));

        }
        public DataSet RunSP_DS(string storedProcedure, params (string, object)[] parameters)
        {
            string connectionString = _configuration.GetConnectionString("Backend");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach ((string parameterKey, object parameterValue) in parameters)
                    {
                        command.Parameters.AddWithValue(parameterKey, parameterValue);
                    }
                }

                connection.Open();
                DataSet dataSet = new DataSet();
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public bool RUNSP_Bool(string storedProcedure, params (string, object)[] parameters)
        {
            string connectionString = _configuration.GetConnectionString("Backend");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach ((string parameterKey, object parameterValue) in parameters)
                    {
                        command.Parameters.AddWithValue(parameterKey, parameterValue);
                    }
                }

                connection.Open();
                bool result = false;
                try
                {
                    command.ExecuteNonQuery();
                    result = true;
                    return result;
                }
                catch
                {
                    return result;
                }
                finally 
                { 
                    connection.Close(); 
                }
            }
        }
    }
}