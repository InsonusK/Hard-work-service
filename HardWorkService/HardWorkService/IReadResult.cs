using System;

namespace HardWorkService
{
    public interface IReadResult
    {
        bool Finish { get; }
        DateTime EndDateTime { get; }
    }
}