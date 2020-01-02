using System;

namespace HardWorkService.Interface
{
    public interface IHardWorkService<in TModel, TResult>
    {
        /// <summary>
        /// Get manager of HardWorkService
        /// </summary>
        IHardWorkServiceManager Manager { get; }

        /// <summary>
        /// Order job NOW
        /// </summary>
        /// <param name="jobData">Data of job</param>
        /// <returns></returns>
        TResult DoNow(TModel jobData);

        /// <summary>
        /// Create ne Job in background
        /// </summary>
        /// <param name="jobData">Data of job</param>
        /// <returns></returns>
        Guid CreateNewJob(TModel jobData);

        /// <summary>
        /// Get result of background job
        /// </summary>
        /// <param name="guid">Job ID</param>
        /// <param name="result">Result of job</param>
        /// <returns></returns>
        bool GetResult(Guid guid, out TResult result);
    }
}