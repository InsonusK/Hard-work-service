using System;
using System.Threading.Tasks;

namespace HardWorkService
{
    public class Result:IReadResult
    {
        public bool Finish { get; set; }
        public DateTime EndDateTime { get; set; }
        public Task<ulong> Task;
    }
}