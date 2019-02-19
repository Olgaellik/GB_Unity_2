using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

namespace Lesson6
{
    public class XMLData : IDataProvider
    {
        private string path;

        public PlayerData Load()

        {
            if (!File.Exists(path)) return default(PlayerData);
            var playerData = new PlayerData();
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    string key = "Name";
                    if (reader.IsStartElement(key)) playerData.Name = reader.GetAttribute("value");
                    
                    key = "HP";
                    if (reader.IsStartElement(key))
                    {
                        var data = float.TryParse(reader.GetAttribute("value"), out playerData.HP);
                        if (!data)
                        {
                            Debug.LogWarning("Wrong format for HP");
                        }
                    }
                    //if (reader.IsStartElement(key)) playerData.HP = float.Parse(reader.GetAttribute("value"));

                    key = "IsVisible";

                    if (reader.IsStartElement(key))
                    {
                        var data = bool.TryParse(reader.GetAttribute("value"), out playerData.IsVisible);
                        if (!data)
                        {
                            Debug.LogWarning("Wrong format for IsVisible");
                        }
                    }

                    //if (reader.IsStartElement(key)) playerData.IsVisible = bool.TryParse(reader.GetAttribute("value"),  out playerData.IsVisible);

                }
            }

            Debug.Log("Data loaded");
            return playerData;

        }

        public void Save(PlayerData playerData)

        {
            var xmlDoc = new XmlDocument();
            var rootNode = xmlDoc.CreateElement("PlayerData");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", playerData.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("HP");
            element.SetAttribute("value", playerData.HP.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsVisible");
            element.SetAttribute("value", playerData.IsVisible.ToString());
            rootNode.AppendChild(element);

            xmlDoc.Save(path);
            Debug.Log("Data.Saved");
        }

        public void SetOptions(string path)

        {
            this.path = Path.Combine(path, "dataxml.xml");
        }
    }
}