namespace Lemonway.Services.Implimentation
{
    /// <summary>
    /// The IFibonnaci Service
    /// </summary>
    public interface IFibonacciService
    {
        /// <summary>
        /// To calculate number's Fibbonacci
        /// </summary>
        /// <param name="number"></param>
        /// <returns>The fibonacci of an interger</returns>
        double Fibonacci(int number);
    }
}
