using System;
using System.Threading.Tasks;

namespace HardWorkService.Models
{
    public class Result : IReadResult
    {
        public Result(DateTime startDateTime, Task<ulong> task)
        {
            StartDateTime = startDateTime;
            Task = task;
        }

        public bool Finish { get; set; }
        public DateTime EndDateTime { get; set; }

        /// <inheritdoc />
        public DateTime StartDateTime { get; }

        public Task<ulong> Task;
    }
}