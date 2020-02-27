using Lemonway.Services.Controllers;
using Lemonway.Services.Implimentation;
using log4net;
using System.Web.Services;

namespace Lemonway.Services
{
    /// <summary>
    /// Summary description for WebServiceXmlToJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceXmlToJson : System.Web.Services.WebService
    {
        /// <summary>
        /// To invoke the XmlToJsonService methods
        /// </summary>
        private readonly IXmlToJsonService xmlToJsonService = DependencyInjector.Retrieve<XmlToJsonService>();

        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// To convernt an xml string to a json
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        [WebMethod]
        public string XmlToJson(string xml)
        {
            log.Info("The Xml to Json service is called");

            if (xml == string.Empty)
            {
                log.Warn("An empty xml is sent to the service");

                return Constants.NoXmlFound;
            }

            return xmlToJsonService.XmlToJson(xml);
        }
    }
}
