using Lemonway.Services.Implimentation;
using log4net;
using System;

namespace Lemonway.Services.Controllers
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// To injecte dependency when the app start
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e"> event</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            log.Info("Injecting dependencies");

            DependencyInjector.Register<IFibonacciService, FibonacciService>();
            DependencyInjector.Register<IXmlToJsonService, XmlToJsonService>();
        }
    }
}