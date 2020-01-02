using System;
using System.Collections.Generic;

namespace HardWorkService.Interface
{
    public interface IHardWorkServiceManager
    {
        /// <summary>
        /// Get count of jobs
        /// </summary>
        /// <param name="onlyOpen">flag show only not finished jobs</param>
        /// <returns></returns>
        int JobsCount(bool onlyOpen = true);

        /// <summary>
        /// Get read only dictionary of jobs
        /// </summary>
        /// <returns></returns>
        IReadOnlyDictionary<Guid, IReadResult> GetJobs();

        /// <summary>
        /// Remove jobs by ID
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>One or more jobs removed</returns>
        bool RemoveJob(params Guid[] guid);

        /// <summary>
        /// Remove finished jobs
        /// </summary>
        void RemoveEndedJobs();
    }
}