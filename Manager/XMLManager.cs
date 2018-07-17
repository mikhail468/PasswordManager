using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace Manager
{
    public class XMLManager
    {
        static string defaultPath = "PW.XML";

        public static bool writeToXml(string name, string pw)
        {
            try
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                XmlWriter writer = XmlWriter.Create(defaultPath, setting);
                writer.WriteStartDocument();
                writer.WriteStartElement("PWClass");
                writer.WriteStartElement("Name");
                writer.WriteValue(name);
                writer.WriteEndElement();
                writer.WriteStartElement("PW");
                writer.WriteValue(pw);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Close();

            }
            catch (Exception error)
            {
                Debug.WriteLine("Error on WriteToXml(string,string,string) - ", error);
                return false;
            }
            return true;
        }

        public static bool writeToXml(List<PWClass> PWList)
        {
            try
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                XmlWriter writer = XmlWriter.Create(defaultPath, setting);
                XmlSerializer serializer = new XmlSerializer(typeof(List<PWClass>));
                serializer.Serialize(writer, PWList);

                writer.Close();
            }
            catch (Exception error)
            {
                Debug.WriteLine("Error on WriteToXML(string,string) - " + error);
                return false;
            }
            return true;
        }

        public static List<PWClass> readFromXmlSerialization()
        {

            try
            {
                XmlReader reader = XmlReader.Create(defaultPath);
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<PWClass>));
                    List<PWClass> list = (List<PWClass>)serializer.Deserialize(reader);

                    reader.Close();

                    return list;

                }
                catch (InvalidOperationException)
                {
                    reader.Close();

                    List<PWClass> list = new List<PWClass>();
                    writeToXml(list);

                    List<PWClass> newList = readFromXmlSerialization();

                    return newList;
                }
            }
            catch (FileNotFoundException)
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                XmlWriter writer = XmlWriter.Create(defaultPath, setting);
                writer.Close();

                List<PWClass> list = new List<PWClass>();
                writeToXml(list);

                List<PWClass> newList = readFromXmlSerialization();

                return newList;
            }
          


        }
    }
}
