using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DB_Layer
{
    public static class DataAccess {
        
        /// <summary>
        /// Method to obtain the username of an generic user profile 
        /// </summary>
        /// <param name="educator"></param>
        /// <returns></returns>
        public static string GetEducatorUsername(string educator)
        {
            Console.WriteLine("---> In GetEducatorUsername");
            XmlDocument _document = new XmlDocument();
            byte[] bytes = File.ReadAllBytes("C:/w/EdgenuityFmwk/WebPage/DB_Layer/UsersRoles.xml");
            string xml = Encoding.UTF8.GetString(bytes);
            try
            {
                _document.LoadXml(xml);
            }
            catch (XmlException e)
            {
                Console.WriteLine("Exception: ",e);
            }

            var doc = (XmlDocument)_document.CloneNode(true);

            XmlNodeList node = doc.GetElementsByTagName("//educators/"+educator+"/user");
            int i = 1;
            foreach(XmlNode nodeElement in node)
            {
                Console.WriteLine("---> Data:"+i+":: " + nodeElement.Value);
                i++;
            }
            
            return null;
        }
        public static string getEnvironmentURL(string portal)
        {
            switch (portal)
            {
                case "QA_Educator":
                    return "https://auth.qa.edgenuity.com/Login/Login/Educator";
                case "QA_Student":
                    return "https://auth.qa.edgenuity.com/Login/Login/Student";
                case "QA_Family":
                    return "https://auth.qa.edgenuity.com/Login/Login/family";
                case "QA_CompassLearning":
                    return "https://qaodypublic.compasslearning.com";
            }
            return null;
        }
    }
}
