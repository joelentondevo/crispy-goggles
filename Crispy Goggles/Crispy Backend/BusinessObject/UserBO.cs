using Crispy_Backend.DataObjects;
using Crispy_Backend.EntityObjects;
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
        public bool UserExists(string username, string password)
        {
            UserLoginEO userEO = new UserDO().ValidateUser(username, password);
            if (userEO != null) 
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
            if (UserExists(username, password) == false)
            {
                return new UserDO().AddUser(username, password);
            }
            else
            {
                return false;
            }
        }
    }
}
