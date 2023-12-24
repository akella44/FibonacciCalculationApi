using System.Collections.Concurrent;

namespace FibonacciCalculationApi.Math
{
    public class FibonacciCalcService : IFibonacciAsyncCalcService
    {
        private ConcurrentDictionary<int, long> _memCache;
        public FibonacciCalcService()
        {
            _memCache = new ConcurrentDictionary<int, long>()
            {
                [0] = 0,
                [1] = 1,
            };
        }

        public async Task<long> CalculateFibonacciAsync(int numArg)
        {
            if (_memCache.ContainsKey(numArg))
                return (_memCache[numArg]);

            Task<long> fibFirstTask = Task.Run(() => CalculateFibonacciAsync(numArg - 2));
            Task<long> fibSecondTask = Task.Run(() => CalculateFibonacciAsync(numArg - 1));

            await Task.WhenAll(fibFirstTask, fibSecondTask);

            _memCache[numArg] = fibFirstTask.Result + fibSecondTask.Result;

            return _memCache[numArg];
        }
    }
}
