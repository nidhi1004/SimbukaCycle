using Microsoft.AspNetCore.Mvc;
using SimCycle.Service;
using System.Net;

namespace SimCycle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BicycleController : ControllerBase
    {
        private readonly ILogger<BicycleController> _logger;
        private readonly SimCycleContext context;
        private IBicycle bicycle;

        public BicycleController(ILogger<BicycleController> logger, SimCycleContext _context)
        {
            _logger = logger;
            context = _context;
            bicycle = new BicycleService(context);
        }
        /// <summary>
        /// Evaluates Distance travelled based on no. of Rotations.
        /// </summary>
        /// <returns>distance travelled.</returns>
        // POST: api/GetDistance
        [HttpGet("GetDistance")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetDistance(int rotations)
        {
            try
            {
                var distance = bicycle.Cycle(rotations);
                return new ObjectResult(new
                {
                    Response = GetResponse()
                });                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Increases Gear level by 1
        /// </summary>
        // GET: api/IncreaseGear
        [HttpGet("IncreaseGear")]

        /// <summary>
        /// Decreases Gear level by 1
        /// </summary>
        // GET: api/DecreaseGear
        public IActionResult IncreaseGear()
        {
            try
            {
                bicycle.IncreaseGear();
                return new ObjectResult(new
                {
                    Response = GetResponse()
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [HttpGet("DecreaseGear")]
        public IActionResult DecreaseGear()
        {
            try
            {
                bicycle.DecreaseGear();
                return new ObjectResult(new
                {
                    Response = GetResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        private APIResponse<Cycle> GetResponse()
        {
            return bicycle.APIResponse;
        }

    }
}