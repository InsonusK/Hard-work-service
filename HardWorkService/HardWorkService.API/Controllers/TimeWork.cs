using System;
using HardWorkService.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardWorkService.API.Controllers
{
    [Route("time-work")]
    public class TimeWork : ControllerBase
    {
        private readonly TimeHardWork _hardWorkService;

        public TimeWork(TimeHardWork hardWorkService)
        {
            _hardWorkService = hardWorkService;
        }

        [HttpPost("now")]
        public ActionResult<ulong> PostNow([FromBody] TimeWorkTask task)
        {
            return Ok(_hardWorkService.DoNow(TimeSpan.FromSeconds(task.Seconds)));
        }
        
        [HttpPost("task")]
        public ActionResult<Guid> PostB([FromBody] TimeWorkTask task)
        {
            return Ok(_hardWorkService.CreateNewWork(TimeSpan.FromSeconds(task.Seconds)));
        }

        public ActionResult<IReadResult> Get(Guid guid)
        {
            if (!_hardWorkService.GetJobs().TryGetValue(guid, out var _result))
            {
                return BadRequest();
            }
            else
            {
                return Ok(_result);
            }
        }
    }
}