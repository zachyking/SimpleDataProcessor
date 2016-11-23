using SimpleDataProcessor.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDataProcessor.DataProcess
{
    public class DataProcessor : IDataProcessor
    {
        public IConfigModel SelectedConfigModel { get; set; }
        public DataProcessor()
        {
            ConfigModel SelectedConfigModel = new ConfigModel();
        }

        public void ProcessData()
        {
            int outputInt;
            float outputFloat;
            string outputString;

            //Check if all inputs are valid, else show message
            if (!string.IsNullOrEmpty(SelectedConfigModel.Type) || !string.IsNullOrEmpty(SelectedConfigModel.FilePath)
                && SelectedConfigModel.Type == "int" || SelectedConfigModel.Type == "string" || SelectedConfigModel.Type == "float" && File.Exists(SelectedConfigModel.FilePath) == true)
            {
                //read txt file
                var txt = File.ReadAllText(SelectedConfigModel.FilePath);

                //split string podla znakov
                char[] charsToSplit = { ' ', ',', ':', ';', '\t' };

                string[] words = txt.Split(charsToSplit);

                //zoradenie stringov
                IEnumerable<string> query = from word in words.Where(x => x.Length >= 2)
                                            orderby word.Substring(0, 1) descending
                                            select word;

                #region for Type int
                if (SelectedConfigModel.Type == "int")
                {
                    foreach (string str in query)
                    {
                        if (int.TryParse(str.ToString(), out outputInt))
                        {
                            ProcessInt(outputInt, SelectedConfigModel.Prefix, out outputString);
                            if (SelectedConfigModel.Output != null)
                            {
                                SelectedConfigModel.Output = SelectedConfigModel.Output + ", " + outputString;
                            }
                            else
                            {
                                SelectedConfigModel.Output = outputString;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(SelectedConfigModel.Output))
                    {
                        MessageBox.Show("Daný formát sa v súbore nenachádza!");
                    }
                }
                #endregion

                #region for Type float
                else if (SelectedConfigModel.Type == "float")
                {
                    foreach (string str in query)
                    {
                        if (float.TryParse(str.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out outputFloat))
                        {
                            ProcessFloat(outputFloat, SelectedConfigModel.Prefix, out outputString);
                            if (SelectedConfigModel.Output != null)
                            {
                                SelectedConfigModel.Output = SelectedConfigModel.Output + ", " + outputString;
                            }
                            else
                            {
                                SelectedConfigModel.Output = outputString;
                            }
                        }
                    }
                    if (string.IsNullOrEmpty(SelectedConfigModel.Output))
                    {
                        MessageBox.Show("Daný formát sa v súbore nenachádza!");
                    }
                }
                #endregion

                #region for Type string
                else if (SelectedConfigModel.Type == "string")
                {
                    foreach (string str in query)
                    {
                        ProcessString(str, SelectedConfigModel.Prefix, out outputString);
                        if (!string.IsNullOrEmpty(SelectedConfigModel.Output))
                        {
                            SelectedConfigModel.Output = SelectedConfigModel.Output + ", " + outputString;
                        }
                        else
                        {
                            SelectedConfigModel.Output = outputString;
                        }
                    }
                }
                #endregion

            }

            else
            {
                MessageBox.Show("Nesprávne zadané parametre!");
            }
        }

        //zprocesuje int na upravený string
        public void ProcessInt(int intInput, string prefix, out string textResult)
        {
            int intResult = intInput + 1000;
            textResult = prefix + intResult.ToString();
        }

        //zprocesuje float na upravený string
        public void ProcessFloat(float floatInput, string prefix, out string textResult)
        {
            int outInt;

            float floatResult = floatInput + 0.5F;
            int.TryParse(floatResult.ToString(), out outInt);
            int intResult = outInt + 1000;
            textResult = prefix + "FLOAT_" + intResult.ToString();
        }

        //zprocesuje string
        public void ProcessString(string stringInput, string prefix, out string textResult)
        {
            textResult = prefix + stringInput;
        }

    }

}
