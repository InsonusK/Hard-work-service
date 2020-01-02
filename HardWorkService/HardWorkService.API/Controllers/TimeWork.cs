using System;
using HardWorkService.API.Models;
using HardWorkService.Interface;
using HardWorkService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HardWorkService.API.Controllers
{
    [Route(RouteName)]
    public class TimeWork : ControllerBase
    {
        public const string RouteName = "time-work";
        private readonly TimeHardWork _hardWorkService;
        private readonly ILogger<TimeWork> _logger;

        public TimeWork(TimeHardWork hardWorkService, ILogger<TimeWork> logger)
        {
            _hardWorkService = hardWorkService;
            _logger = logger;
        }

        [HttpPost("now")]
        public ActionResult<ulong> PostNow([FromBody] TimeWorkTask task)
        {
            _logger.LogInformation("Post Now, spend {1} seconds", task.Seconds);
            return Ok(_hardWorkService.DoNow(TimeSpan.FromSeconds(task.Seconds)));
        }

        [HttpPost("task")]
        public ActionResult<Guid> PostTask([FromBody] TimeWorkTask task)
        {
            _logger.LogInformation("Post Task, spend {1} seconds", task.Seconds);
            return Ok(_hardWorkService.CreateNewJob(TimeSpan.FromSeconds(task.Seconds)));
        }

        [HttpGet("{guid}")]
        public ActionResult<IReadResult> Get(Guid guid)
        {
            if (!_hardWorkService.Manager.GetJobs().TryGetValue(guid, out var _result))
            {
                return BadRequest();
            }
            else
            {
                return Ok(_result);
            }
        }
        
        [HttpGet("count")]
        public ActionResult<int> Count()
        {
            return _hardWorkService.Manager.JobsCount();
        }
    }
}