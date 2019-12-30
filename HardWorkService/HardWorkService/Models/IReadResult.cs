using System;

namespace HardWorkService.Models
{
    public interface IReadResult
    {
        bool Finish { get; }
        DateTime EndDateTime { get; }
        DateTime StartDateTime { get; }
    }
}