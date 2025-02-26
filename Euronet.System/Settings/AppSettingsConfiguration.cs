using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.System.Settings
{
    public class AppSettingsConfiguration
    {
        public static IConfiguration app_settings { get; set; }
    }
}
