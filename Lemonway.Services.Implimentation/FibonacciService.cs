using log4net;
using System;

namespace Lemonway.Services.Implimentation
{
    /// <summary>
    /// The Fibonacci Service
    /// </summary>
    public class FibonacciService : IFibonacciService
    {
        /// <summary>
        /// To log informations 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The FibonacciService Constructor
        /// </summary>
        public FibonacciService()
        {
            log.Info("The fibonacci service is initilized");

            Initialize();
        }

        /// <summary>
        /// Respresent an array that will hold the fibonacci results
        /// </summary>
        private double[] fibonacciArray;

        /// <summary>
        /// To check the initialization
        /// </summary>
        private bool IsInitialized;

        /// <summary>
        /// To calculate number's Fibbonacci
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The fibonacci of an interger</returns>
        public double Fibonacci(int number)
        {
            return GetFibonacci(number);
        }


        /// <summary>
        /// To return the fibonacci
        /// </summary>
        /// <param name="number">An interger</param>
        /// <returns>Return the fibonacci of the number <otherwise>-1s</otherwise></returns>
        private double GetFibonacci(int number)
        {
            if (number > 100 || number <= 0)
            {
                return Constants.UnexpectedNumber;
            }

            return fibonacciArray[number];
        }

        /// <summary>
        /// To initialize the needed data at once, to gain some perfermance
        /// </summary>
        private void Initialize()
        {
            if (IsInitialized)
            {
                return;
            }

            try
            {
                fibonacciArray = new double[Constants.MaxLength];
                IsInitialized = true;
                fibonacciArray[1] = fibonacciArray[2] = 1;

                for (int i = 3; i < 101; i++)
                    fibonacciArray[i] = fibonacciArray[i - 1] + fibonacciArray[i - 2];

                log.Info("The fibonacci of the numbers from 1 to 100 is calculated correctlly");
            }
            catch (Exception ex)
            {
                log.Error("An exception has occured : " + ex.Message);
            }
        }
    }
}
