using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//for XML
using System.Xml;
using System.Xml.Linq;

namespace SettingsChanger
{
    public class XMLChanger
    {
        public void Change(string path)
        {
            XDocument config = XDocument.Load(path);

            ChangeDBConfigs(config);
            ChangeMySectionConfigs(config);

            config.Save(path);
        }

        private void ChangeDBConfigs(XDocument config)
        {
            var nodes = config
                       .Descendants("connectionStrings")
                       .Elements("add").ToList();

            foreach (var n in nodes)
            {
                if (n.Attribute("name").Value == "Connection1")
                {
                    n.Attribute("connectionString").Value = "Data Source=localhost;Initial Catalog=NewDB;";
                }
            }
        }

        private void ChangeMySectionConfigs(XDocument config)
        {
            var addNodes = config
                       .Descendants("MySection")
                       .Elements("SubSection")
                       .Elements("add").ToList();

            foreach (var addNote in addNodes)
            {
                var myItemNote = addNote.Elements("MyItem").First();

                if (addNote.Attribute("Name").Value == "item1")
                {
                    myItemNote.Attribute("Param1").Value = "false";
                    myItemNote.Attribute("Param2").Value = "2";
                    myItemNote.Attribute("Param2").Value = "44";
                }
                else 
                {
                    myItemNote.Attribute("Param2").Value = "55";
                }
            }
        }

    }
}
