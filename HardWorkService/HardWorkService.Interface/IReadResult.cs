using System;

namespace HardWorkService.Interface
{
    public interface IReadResult
    {
        bool Finish { get; }
        DateTime EndDateTime { get; }
        DateTime StartDateTime { get; }
    }
}