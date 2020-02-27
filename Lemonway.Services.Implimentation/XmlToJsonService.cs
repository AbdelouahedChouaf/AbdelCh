using log4net;
using Newtonsoft.Json;
using System;
using System.Xml;

namespace Lemonway.Services.Implimentation
{
    /// <summary>
    /// The XmlToJsonService 
    /// </summary>
    public class XmlToJsonService : IXmlToJsonService
    {
        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// To parse xml to json
        /// </summary>
        /// <param name="xml">The xml format</param>
        /// <returns>The json format</returns>
        public string XmlToJson(string xml)
        {
            if (xml == string.Empty)
            {
                return Constants.NoXmlFound;
            }

            try
            {
                log.Info("Trying the convert xml to json");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                string json = JsonConvert.SerializeXmlNode(doc);

                log.Info("Xml to json is converted");

                return json;
            }
            catch (Exception ex)
            {
                log.Error("An exception has occured : " +ex.Message);

                return Constants.BadXmlFormat;
            }
        }
    }
}
