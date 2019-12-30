using System;
using System.Threading.Tasks;

namespace HardWorkService
{
    public class Result
    {
        public bool Finish;
        public DateTime EndDateTime;
        public Task<ulong> Task;
    }

}