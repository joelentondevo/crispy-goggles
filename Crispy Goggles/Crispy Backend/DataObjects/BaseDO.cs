using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Crispy_Backend.BusinessObject;

namespace Crispy_Backend.DataObjects
{
    internal class BaseDO
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        internal BaseDO()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("Backend");
        } 

        internal string GetConnectionString()
        {
            return connectionString;
        }

        public DataSet RunSP_DS(string connectionString, string storedProcedure, params (string, object)[] parameters)
        {;
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

        public bool RUNSP_Bool(string connectionString, string storedProcedure, params (string, object)[] parameters)
        {

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
