using Market.Common.Contract;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Market.Common.Helpers
{
    public class SimpleLogger : ILogger
    {
        public  string FolderPath = ConfigurationManager.AppSettings["FolderPath"] ;
        
        public  string LogFile = ConfigurationManager.AppSettings["LogFile"];
        public void LogError(Exception ex)
        {
            var stringData = CreateErrorStr(ex);
            WriteMessage(stringData);
        }

        public void LogError(string message)
        {
            var stringData = CreateErrorStr(message);
            WriteMessage(stringData);
        }

        public void LogInfo(string message)
        {
            var stringData = CreateInforStr(message);
            WriteMessage(stringData);
        }
        public string CreateErrorStr(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[ERROR] ");
            stringBuilder.Append(DateTime.UtcNow.ToString() + " ");
            stringBuilder.Append(ex.Message + " ");
            stringBuilder.Append(ex.StackTrace + " ");
            stringBuilder.Append(ex.Data + " ");
            stringBuilder.Append(ex.Source + " ");

            return stringBuilder.ToString();
        }
        public string CreateErrorStr(string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[ERROR] ");
            stringBuilder.Append(DateTime.UtcNow.ToString() + " ");
            stringBuilder.Append(message);

            return stringBuilder.ToString();
        }
        public string CreateInforStr(string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[INFO]  ");
            stringBuilder.Append(DateTime.UtcNow.ToString() + " ");
            stringBuilder.Append(message);

            return stringBuilder.ToString();
        }
        public void WriteMessage(string source)
        {
            string writePath = Path.Combine(FolderPath,LogFile);
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");

            writePath = Path.Combine(path, writePath);

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath,true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(source);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
