using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using POCWebAPI.Service.DataStorage;
using POCWebAPI.Service.HubConfig;
using POCWebAPI.Service.TimeFeatures;


namespace RealTimeCharts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly TimeManager _timer;

        public ChartController(IHubContext<ChartHub> hub, TimeManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        /// <summary>
        /// Gets data for the chart. Sets/Resets timer for getting new data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            if (!_timer.IsTimerStarted)
            {
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            }

            return Ok(new { Message = "Requeste Completed" });
        }
    }
}
