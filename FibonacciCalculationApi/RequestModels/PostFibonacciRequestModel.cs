namespace FibonacciCalculationApi.RequestModels
{
    public class PostFibonacciRequestModel
    {
        public List<int> ArgsList { get; set; }
        public string QueueName { get; set; }
    }
}
