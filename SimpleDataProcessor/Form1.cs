using SimpleDataProcessor.Config;
using SimpleDataProcessor.DataProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDataProcessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessData_Click(object sender, EventArgs e)
        {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.SelectedConfigModel = new ConfigModel();

            dataProcessor.SelectedConfigModel.FilePath = txtFilePath.Text;
            dataProcessor.SelectedConfigModel.Type = txtType.Text;
            dataProcessor.SelectedConfigModel.Prefix = txtPrefix.Text;
            dataProcessor.ProcessData();
            txtOutput.Text = dataProcessor.SelectedConfigModel.Output; ;

        }
    }
}
