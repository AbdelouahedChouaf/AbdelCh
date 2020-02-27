namespace Lemonway.Services.Implimentation
{
    /// <summary>
    /// The IXmlToJsonService interface
    /// </summary>
     public interface IXmlToJsonService
    {
        /// <summary>
        /// To convert xml to json
        /// </summary>
        /// <param name="xml">xml format</param>
        /// <returns>json format<otherwise>Bad json format</otherwise></returns>
        string XmlToJson(string xml);
    }
}
