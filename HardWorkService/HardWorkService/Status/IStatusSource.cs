using System;
using System.Collections.Generic;

namespace HardWorkService
{
    public interface IStatusSource
    {
        IReadOnlyDictionary<Guid, IReadResult> GetJobs();
    }
}