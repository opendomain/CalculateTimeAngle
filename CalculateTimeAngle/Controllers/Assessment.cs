using Microsoft.AspNetCore.Mvc;

namespace CalculateTimeAngle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Assessment : ControllerBase
    {

        private readonly ILogger<Assessment> _logger;

        public Assessment(ILogger<Assessment> logger)
        {
            _logger = logger;
        }

        // TODO: Get vs POST
        // TODO: async
        // TODO: add tests
        // TODO: should response be JSON?
        [Route("api/CalculateTimeAngle/")]
        [HttpGet]
        public double Get(int hour, int minutes)
        {
            double angle = 0;

            // TODO: Try/catch
            // TODO: Limit hour / minutes
            // TODO: put logic in "business class"
            angle = hour + minutes;

            return angle;
        }
    }
}
