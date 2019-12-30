using System;
using System.Collections.Generic;
using HardWorkService.Models;

namespace HardWorkService.Status
{
    public interface IStatusSource
    {
        IReadOnlyDictionary<Guid, IReadResult> GetJobs();
    }
}