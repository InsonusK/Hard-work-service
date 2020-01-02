using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HardWorkService.Interface;
using HardWorkService.Models;

namespace HardWorkService
{
    public class TimeHardWork : IHardWorkService<TimeSpan, ulong>
    {
        public TimeHardWork()
        {
            Jobs = new ConcurrentDictionary<Guid, Result>();
            Manager = new TimeHardWorkManager(Jobs);
        }

        private ConcurrentDictionary<Guid, Result> Jobs;


        #region Implementation of IHardWorkService<in TimeSpan,ulong>

        /// <inheritdoc />
        public IHardWorkServiceManager Manager { get; }

        public ulong DoNow(TimeSpan time)
        {
            return Work(time);
        }

        /// <inheritdoc />
        public Guid CreateNewJob(TimeSpan jobData)
        {
            Guid newGuid = Guid.NewGuid();

            var task = new Task<ulong>(() =>
            {
                ulong answer = DoNow(jobData);
                var job = Jobs[newGuid];
                lock (job)
                {
                    job.EndDateTime = DateTime.Now;
                    return answer;
                }
            });
            if (!Jobs.TryAdd(newGuid, new Result(DateTime.Now, task)))
            {
                task.Dispose();
                throw new DuplicateNameException("Guid duplicate");
            }

            task.Start();
            return newGuid;
        }

        /// <inheritdoc />
        public bool GetResult(Guid guid, out ulong result)
        {
            if (!Jobs.TryGetValue(guid, out var _result) || !_result.Finish)
            {
                result = 0;
                return false;
            }

            result = _result.Task.Result;
            return true;
        }

        #endregion

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
    }
}