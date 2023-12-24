namespace FibonacciCalculationApi.Math
{
    public interface IFibonacciAsyncCalcService
    {
        public Task<long> CalculateFibonacciAsync(int numArg);
    }
}
