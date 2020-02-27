using Lemonway.Services.Controllers;
using Lemonway.Services.Implimentation;
using log4net;
using System.Web.Services;

namespace Lemonway.Services
{
    /// <summary>
    /// Summary description for WebServiceFibonacci
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceFibonacci : System.Web.Services.WebService
    {
        /// <summary>
        /// To invoke the fibinacciService methods
        /// </summary>
        private readonly IFibonacciService fibonacciService = DependencyInjector.Retrieve<FibonacciService>();

        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// This is a Fibinnaci function
        /// </summary>
        /// <param name="n">The integar parameter</param>
        /// <returns>Retourn the result as double</returns>

        [WebMethod]
        public double Fibonacci( int number)
        {
            log.Info("The Fibonacci Service is called");

            if (number > 100 || number <= 0)
            {
                log.Warn("You have sent an out of range value");

                return Constants.UnexpectedNumber;
            }

            return fibonacciService.Fibonacci(number);
        }
    }
}
