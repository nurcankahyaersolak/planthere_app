using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Application.Configurations
{
    public class SettingsOption
    {
        public string? AllowedOrigins { get; set; }
        public string? CorsPolicyName { get; set; }

    }
}
