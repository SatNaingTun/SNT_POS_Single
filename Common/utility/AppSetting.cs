using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;


namespace SNT_POS_Common.utility
{
   public class AppSetting
    {
        Configuration config;

        public AppSetting()
        {
           
           config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
          
            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //fileMap.ExeConfigFilename = Path.GetFullPath( Environment.CurrentDirectory+"\\"+ appname + ".exe.config");
            //config = ConfigurationManager.OpenMappedExeConfiguration(fileMap,ConfigurationUserLevel.None); 
           // config = ConfigurationManager.OpenExeConfiguration(Path.Combine(Environment.CurrentDirectory + "\\" + appname + ".exe.config"));
            
        }
       

        //Get connection string from App.Config file
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        //Save connection string to App.config file
        public void SaveConnectionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.OleDb";
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}
