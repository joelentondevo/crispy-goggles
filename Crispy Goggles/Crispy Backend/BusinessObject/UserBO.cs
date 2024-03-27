using Crispy_Backend.DataObjects;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.BusinessObject
{
    // contains the methods to interact with UserDO, retrieving UserEO etc
    public class UserBO
    {
        BaseDO baseDO = new BaseDO();
        public bool ValidateUsername(string username, string password)
        {
            DataSet queryResult = baseDO.RunSP_DS(baseDO.GetConnectionString(), "p_LoginData_f",
            ("@username", username),
            ("@password", password));

            if(queryResult.Tables.Count != 0 && queryResult.Tables[0].Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewUser(string username, string password)
        {
            DataSet queryResult = baseDO.RunSP_DS(baseDO.GetConnectionString(), "p_LoginData_f",
                ("@username", username),
                ("@password", password));
            if (queryResult.Tables[0].Rows.Count == 0)
            {
                return baseDO.RUNSP_Bool(baseDO.GetConnectionString(), "p_RegisterUser_f", ("@username", username),
                ("@password", password));
            }
            else
            {
                return false;
            }
        }
    }
}
