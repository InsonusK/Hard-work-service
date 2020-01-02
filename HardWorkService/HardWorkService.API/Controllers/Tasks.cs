using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HardWorkService.Interface;
using HardWorkService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HardWorkService.API.Controllers
{
    [Route("tasks")]
    public class Tasks : ControllerBase
    {
        private readonly TimeHardWork _service;

        public Tasks(TimeHardWork service)
        {
            this._service = service;
        }

        [HttpGet("count")]
        public ActionResult<Tuple<string, int>[]> Count()
        {
            var _return = new Tuple<string, int>[]
                {new Tuple<string, int>(TimeWork.RouteName, _service.Manager.JobsCount())};
            return Ok(_return);
        }

        [HttpGet("list")]
        public ActionResult<Tuple<string, IReadOnlyDictionary<Guid, IReadResult>>[]> List()
        {
            var _return = new[]
                {new Tuple<string, IReadOnlyDictionary<Guid, IReadResult>>(TimeWork.RouteName, _service.Manager.GetJobs())};
            return Ok(_return);
        }

        [HttpPost("remove-finished")]
        public void RemoveFinished()
        {
           _service.Manager.RemoveEndedJobs();
        }
    }
}