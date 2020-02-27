using NUnit.Framework;
using System;

namespace Lemonway.Services.Implimentation.Tests
{
    /// <summary>
    /// The XmlToJsonTests class used to test the XmlToJsonService
    /// </summary>
    [TestFixture]
    public class XmlToJsonTests : BaseClassTest
    {
        /// <summary>
        /// To test the case when the xml provided is empty
        /// </summary>
        [Test]
        public void WhenXmlIsEmpty_ReturnNoXmlIsFound()
        {
            _mockedXmlToJsonService.Setup(p => p.XmlToJson(string.Empty)).Returns(Constants.NoXmlFound);

            var result = _xmlToJsonService.XmlToJson(string.Empty);

            Assert.AreEqual(result, Constants.NoXmlFound, "You must return No Xml Found");
        }

        /// <summary>
        /// To test the case when xml in good format
        /// </summary>
        [Test]
        public void WhenXmlIsInGoodFormat_ReturnJsonResult()
        {
            _mockedXmlToJsonService.Setup(p => p.XmlToJson(Constants.XmlInGoodFormt)).Returns(Constants.JsonFormat);

            var result = _xmlToJsonService.XmlToJson(Constants.XmlInGoodFormt);

            Assert.AreEqual(result, Constants.JsonFormat, "The result is not correct check it out");
        }

        /// <summary>
        /// To test the case when the provided Xml is in bad format
        /// </summary>
        [Test]
        public void WhenXmlIsInBadFormat_ReturnBadXmlFormat()
        {
            _mockedXmlToJsonService.Setup(p => p.XmlToJson(Constants.XmlInBadFormat)).Throws(new Exception());

            var result = _xmlToJsonService.XmlToJson(Constants.XmlInBadFormat);

            Assert.AreEqual(result, Constants.BadXmlFormat, "You must return Xml Bad format");
        }
    }
}
