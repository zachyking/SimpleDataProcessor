using SimpleDataProcessor.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataProcessor.DataProcess
{
    public interface IDataProcessor
    {
        IConfigModel SelectedConfigModel { get; set; }
        void ProcessData();
    }
}
