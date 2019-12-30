using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HardWorkService.Models;
using HardWorkService.Status;

namespace HardWorkService
{
    public class TimeHardWork : IStatusSource
    {
        ConcurrentDictionary<Guid, Result> Jobs = new ConcurrentDictionary<Guid, Result>();

        public Guid CreateNewWork(TimeSpan time)
        {
            Guid newGuid = Guid.NewGuid();
           
            var task = new Task<ulong>(() =>
            {
                ulong answer = DoNow(time);
                var job = Jobs[newGuid];
                lock (job)
                {
                    job.EndDateTime = DateTime.Now;
                    job.Finish = true;
                    return answer;
                }
            });
            if (!Jobs.TryAdd(newGuid, new Result( DateTime.Now,task)))
            {
                task.Dispose();
                throw new DuplicateNameException("Guid duplicate");
            }
            task.Start();
            return newGuid;
        }

        public ulong DoNow(TimeSpan time)
        {
            return Work(time);
        }

        public static ulong Work(TimeSpan time)
        {
            DateTime _time = DateTime.Now.AddSeconds(time.TotalSeconds);
            return Work(_time);
        }

        public static ulong Work(DateTime timeEnd)
        {
            ulong counter = 0;
            while (DateTime.Now < timeEnd)
            {
                double someValue = Math.Cos(new Random().NextDouble());
                counter++;
            }

            return counter;
        }

        #region Implementation of IStatusSource

        /// <inheritdoc />
        public IReadOnlyDictionary<Guid, IReadResult> GetJobs()
        {
            return new ConcurrentDictionary<Guid, IReadResult>(Jobs.ToDictionary(kvp => kvp.Key,
                kvp => (IReadResult) kvp.Value));
        }

        #endregion
    }
}