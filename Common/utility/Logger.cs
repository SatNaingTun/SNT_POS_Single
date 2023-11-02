using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SNT_POS_Common.utility
{
    class Logger
    {
        public static void errorLog(string Message)
        {
            WriteToFile(Message, LogType.Error);
        }
        public static void infoLog(string Message)
        {
            WriteToFile(Message, LogType.Information);
        }
        public static void WriteToFile(string Message,LogType logtype)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine("LogType:" + logtype.ToString() + " ");
                        sw.Write("at " + DateTime.Now+" ");
                        sw.WriteLine(Message);
                     
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine("LogType:" + logtype.ToString() + " ");
                        sw.Write("at " + DateTime.Now);
                        sw.WriteLine(Message);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public enum LogType
        {
           
            Exception,
           
            Error,
           
            Warning,
           
            Debug,
            
            Information
        }
    }
}
