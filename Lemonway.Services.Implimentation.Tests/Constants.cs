namespace Lemonway.Services.Implimentation.Tests
{
    /// <summary>
    /// Represents a class of constants
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// We return this if the needed data is not calculated
        /// </summary>
        internal const int UnexpectedNumber = -1;

        /// <summary>
        ///When no xml format sent 
        /// </summary>
        internal const string NoXmlFound = "No xml format detected";

        /// <summary>
        /// Bad xml format
        /// </summary>
        internal const string BadXmlFormat = "Bad Xml format";

        /// <summary>
        /// Xml in good format
        /// </summary>
        internal const string XmlInGoodFormt = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>";

        /// <summary>
        /// Json Format
        /// </summary>
        internal const string JsonFormat = "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"project01\"}}}";

        /// <summary>
        /// Xml in bad format
        /// </summary>
        internal const string XmlInBadFormat = "<foo>hello</bar";
    }
}
