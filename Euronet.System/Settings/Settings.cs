using Euronet.System.Settingss;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Euronet.System;

namespace Euronet.System.Settings
{
    public class Settings
    {
        public Settings() { }

        private static volatile Settings instance;
        private static object instanceLock = new object();

        public static Settings Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new Settings();

                    return instance;
                }

            }
        }

        public static void Initialize(IConfiguration configuration)
        {
            lock (instanceLock)
            {
                instance = configuration.GetSection("Settings").Get<Settings>();
            }
        }


        public AuditLogSettings AuditLogSettings { get; set; }

        public AppSettings AppSettings { get; set; }

        public SwaggerSettings SwaggerSettings { get; set; }

        public JwtSettings JwtSettings { get; set; }

    }
}