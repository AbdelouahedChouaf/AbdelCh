using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace Lemonway.Services.Implimentation.Tests
{
    /// <summary>
    /// The BaseClassTest used to mock services
    /// </summary>
    [TestFixture]
    public class BaseClassTest
    {
        /// <summary>
        ///The mocked FibonacciService
        /// </summary>
        protected Mock<IFibonacciService> _mockedFibonacciService;

        /// <summary>
        /// The mocked XmlToJsonService
        /// </summary>
        protected Mock<IXmlToJsonService> _mockedXmlToJsonService;

        /// <summary>
        /// Instanciate the fibonacci Service
        /// </summary>
       protected IFibonacciService _fibonacciService;

        /// <summary>
        /// Instanciate the xmlToJson Service
        /// </summary>
       protected IXmlToJsonService _xmlToJsonService;

        /// <summary>
        /// The base set up
        /// </summary>
        [OneTimeSetUp]
        public void BaseSetUp()
        {
            _mockedFibonacciService = new Mock<IFibonacciService>();
            _mockedXmlToJsonService = new Mock<IXmlToJsonService>();
            _fibonacciService = new FibonacciService();
            _xmlToJsonService = new XmlToJsonService();
        }

        /// <summary>
        /// The base tearDown
        /// </summary>
        [OneTimeTearDown]
        public void BaseTearDown()
        {
            _mockedFibonacciService.Reset();
            _mockedXmlToJsonService.Reset();
        }
    }
}
