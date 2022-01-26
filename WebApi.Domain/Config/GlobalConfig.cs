using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Config
{
    public class GlobalConfig
    {
        public const string SectionName = "WebApi";

        public string AdminDbConnectionString { get; set; } = "unconfigured";

        public string AdminDbPassword { get; set; } = "unconfigured";
    }
}
