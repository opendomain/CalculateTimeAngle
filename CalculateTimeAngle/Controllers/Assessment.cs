using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            try
            {
                if (hour < 1 || hour > 12) throw new Exception("Invalid hour");
                if (minutes < 0 || minutes > 59) throw new Exception("Invalid Minutes");

                // hour angle starts at 0 = 12  == 360
                // TODO: Make constants
                int adjustedHour = ((360 / 12) * hour) % 360;
                int adjustedMinutes = ((360 / 60) * minutes % 360);

                angle = adjustedHour + (adjustedMinutes / 100);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                throw;
            }

            // TODO: put logic in "business class"

            return angle;
        }
    }
}
