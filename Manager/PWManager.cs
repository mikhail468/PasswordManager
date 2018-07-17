using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Manager
{
    public class PWManager
    {
        public static bool savePWSerialization(string name, string pw)
        {
            List<PWClass> list = getPWSerialization();
            PWClass element = new PWClass(name, pw);
            list.Add(element);

            if (XMLManager.writeToXml(list))
            {
                return true;
            }
            else return false;
        }

        public static List<PWClass> getPWSerialization()
        {
            List<PWClass> studentList = XMLManager.readFromXmlSerialization();
            return studentList;
        }

        public static bool saveToXML(List<PWClass> pwList)
        {
            bool success = XMLManager.writeToXml(pwList);
            if (success) return true;
            else return false;
        }
    }
}
