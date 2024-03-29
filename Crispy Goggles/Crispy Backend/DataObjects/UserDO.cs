﻿using Crispy_Backend.EntityObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.DataObjects
{
    internal class UserDO : BaseDO
    {
        internal UserEO ValidateUser(string username, string password)
        {
            DataSet queryResult = new UserDO().RunSP_DS("p_LoginData_f",
            ("@username", username),
            ("@password", password));

            if (queryResult.Tables.Count != 0 && queryResult.Tables[0].Rows.Count != 0)
            {
                UserEO UserInfo = new UserEO();
                UserInfo.Username = queryResult.Tables[0].Rows[0]["Username"].ToString();
                UserInfo.Password = queryResult.Tables[0].Rows[0]["Password"].ToString();
                return UserInfo;
            }
            else
            {
                return null;
            }
        }

        internal bool AddUser(string username, string password)
        {
             return RUNSP_Bool("p_RegisterUser_f", ("@username", username),
                ("@password", password));

        }
    }
}
