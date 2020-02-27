using Lemonway.Services.ConsoleApp.OptionOne.FibonacciService;
using Lemonway.Services.ConsoleApp.OptionOne.XmlToJsonService;
using System;
using System.Threading;

namespace Lemonway.Services.ConsoleApp.OptionOne
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Fibonacci Consumer

            WebServiceFibonacci fibonacciConsumer = new WebServiceFibonacci();

            Console.WriteLine(" Calling Web Service Fibonacci Methods");
            Console.WriteLine(" ---------------------");
            Console.WriteLine("\n Calling Fibonacci Method with 100");

            Console.WriteLine(fibonacciConsumer.Fibonacci(100));

            #endregion


            #region XmlToJson Consumer

            Thread.Sleep(3000);

            WebServiceXmlToJson xmlToJsonConsumer = new WebServiceXmlToJson();

            Console.WriteLine(" \nCalling Web Service XmlToJson Methods");
            Console.WriteLine(" ---------------------");
            Console.WriteLine("\n Calling XmlToJson Method with <foo>bar</foo>");

            Console.WriteLine(xmlToJsonConsumer.XmlToJson("<foo>bar</foo>"));
            #endregion
            Console.Read();
        }
    }
}
