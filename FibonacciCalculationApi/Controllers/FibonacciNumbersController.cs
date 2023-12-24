using FibonacciCalculationApi.Math;
using FibonacciCalculationApi.RabbitMq;
using FibonacciCalculationApi.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FibonacciCalculationApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FibonacciNumbersController : ControllerBase
    {
        private readonly ILogger<FibonacciNumbersController> _logger;
        private readonly IRabbitMqService _rabbitMqService;
        private readonly IFibonacciAsyncCalcService _fibCalcService;
        public FibonacciNumbersController(
            ILogger<FibonacciNumbersController> logger,
            IRabbitMqService rabbitMqService,
            IFibonacciAsyncCalcService fibCalcService
            )
        {
            _logger = logger;
            _rabbitMqService = rabbitMqService;
            _fibCalcService = fibCalcService;
        }

        [HttpPost]
        public async Task<IActionResult> PostFibonacciAsync(PostFibonacciRequestModel requestBody)
        {
            if (requestBody.ArgsList == null | requestBody.QueueName == null)
            {
                return BadRequest("Body request cant be empty");
            }

            try
            {
                foreach (var item in requestBody.ArgsList)
                {
                    long fibResult = await _fibCalcService.CalculateFibonacciAsync(item);

                    _rabbitMqService.PutToQueue(queueName: requestBody.QueueName,
                        message: fibResult.ToString());
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error: {ex}");
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
