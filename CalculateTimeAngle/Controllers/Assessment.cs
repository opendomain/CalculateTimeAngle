using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculateTimeAngle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Assessment : ControllerBase
    {

        private readonly ILogger<Assessment> _logger;

        private const int DegreesInCircle = 360;

        private const int MinimumHour = 1;
        private const int MaximumHour = 12;
        private const int NumberOfHoursPerClock = 12;

        private const int MinimumMinutes = 0;
        private const int MaximumMinutes = 59;
        private const int NumberOfMinutesPerHour = 60;

        // TODO: move this to contructor or business logic?
        private int anglePerHour = (DegreesInCircle / NumberOfHoursPerClock);
        private int anglePerMinute = (DegreesInCircle / NumberOfMinutesPerHour);

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
                if ( (hour < MinimumHour) || (hour > MaximumHour) ) throw new Exception("Invalid hour");
                if ( (minutes < MinimumMinutes) || (minutes > MaximumMinutes) ) throw new Exception("Invalid Minutes"); 

                // hour angle starts at 0 = 12  == 360

                int angleHour = (anglePerHour * hour) % DegreesInCircle;
                int angleMinutes = (anglePerMinute * minutes % DegreesInCircle);

                // Adjust that hour hand moves per minute
                double adjustedHour = (double) angleHour;
                if (angleMinutes > 0) adjustedHour += ((double) anglePerHour / ( (double)DegreesInCircle / (double) angleMinutes));

                angle = Math.Abs(adjustedHour - ((double) angleMinutes));
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
