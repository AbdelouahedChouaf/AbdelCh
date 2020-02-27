using NUnit.Framework;

namespace Lemonway.Services.Implimentation.Tests
{
    /// <summary>
    /// The FibonacciTests class used to test FibonacciService
    /// </summary>
    [TestFixture]
    public class FibonacciTests :BaseClassTest
    {
        /// <summary>
        /// To test the case when an out of range value is passed to fibonacci method
        /// </summary>
        [Test]
        public void WhenOutRangeValuePassed_ReturnNegatifValue()
        { 
            _mockedFibonacciService.Setup(p => p.Fibonacci(1000)).Returns(-1);
            

            var result = _fibonacciService.Fibonacci(1000);

            Assert.AreEqual(Constants.UnexpectedNumber, result, "Is not correct value check it out");
        }

        /// <summary>
        /// To test the case when a negatif  value is passed to fibonacci method
        /// </summary>
        [Test]
        public void WhenNegatifValuePassed_ReturnNegatifValue()
        {
            _mockedFibonacciService.Setup(p => p.Fibonacci(-10)).Returns(-1);

            var result = _fibonacciService.Fibonacci(-10);

            Assert.AreEqual(Constants.UnexpectedNumber, result, "Is not correct value check it out");
        }

        /// <summary>
        /// To test the case when a good  value is passed to fibonacci method
        /// </summary>
        [Test]
        public void WhenGoodValuePassed_ReturnExpectedValue()
        {
            _mockedFibonacciService.Setup(p => p.Fibonacci(2)).Returns(-1);

            var result = _fibonacciService.Fibonacci(2);

            //We already know that fibinacci of 2 is 1
            Assert.AreEqual(1, result, "Is not correct value check it out");
        }
    }
}
