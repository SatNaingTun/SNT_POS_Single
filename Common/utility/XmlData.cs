using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SNT_POS_Common.utility
{
   public class XmlData
    {
        XDocument xdoc; string uri;
        public XmlData(string uri)
        {
            this.uri=uri;
            xdoc = XDocument.Load(uri);   
        }
        public string readConnectionString()
        {

            var targetnode = xdoc.Root.Descendants("connectionStrings").FirstOrDefault();
            var conn = targetnode.Descendants("add").FirstOrDefault().Attribute("connectionString");

            return conn.Value;
          
        }

        public void updateConnectionString(string connectionPath)
        {
            var targetnode = xdoc.Root.Descendants("connectionStrings").FirstOrDefault();
            var conn = targetnode.Descendants("add").FirstOrDefault().Attribute("connectionString");
            conn.Value = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True", connectionPath);
            xdoc.Save(uri);

        }
    }
}
