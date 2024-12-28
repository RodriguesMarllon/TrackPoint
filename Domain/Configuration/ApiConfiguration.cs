using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public class ApiConfiguration
    {
        public string? BaseUrl { get; set; }
        public Dictionary<string, Dictionary<string, string>>? Controllers { get; set; }
    }
}
