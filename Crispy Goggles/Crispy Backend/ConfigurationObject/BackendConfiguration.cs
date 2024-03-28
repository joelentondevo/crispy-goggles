using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crispy_Backend.ConfigurationObject
{

    internal class BackendConfiguration
    {
        IConfiguration _configurationvalue;

        internal BackendConfiguration() 
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            _configurationvalue = configuration;
        }

        internal IConfiguration GetConfig() 
        { 
            return _configurationvalue; 
        }
    }
}
