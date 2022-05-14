using Microsoft.AspNetCore.Mvc;

namespace pucminas.futebol.time.api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("times")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }
    }
}