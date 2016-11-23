using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataProcessor.Config
{
    public interface IConfigModel
    {
        string Type { get; set; }
        string Prefix { get; set; }
        string FilePath { get; set; }
        string Output { get; set; }
    }
}
