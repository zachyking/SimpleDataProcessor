using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataProcessor.Config
{
    public class ConfigModel : IConfigModel
    {
        public string Type { get; set; }
        public string Prefix { get; set; }
        public string FilePath { get; set; }
        public string Output { get; set; }
    }
}
