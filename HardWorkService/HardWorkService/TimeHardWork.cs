using System;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HardWorkService
{
    public class TimeHardWork
    {
        ConcurrentDictionary<Guid, Result> Jobs = new ConcurrentDictionary<Guid, Result>();

        HardWorkStatus Status =>
            new HardWorkStatus(
                new ConcurrentDictionary<Guid, IReadResult>(Jobs.ToDictionary(kvp => kvp.Key,
                    kvp => (IReadResult) kvp.Value)));

        public Guid CreateNewWork(TimeSpan time)
        {
            Guid newGuid = Guid.NewGuid();
            if (!Jobs.TryAdd(newGuid, new Result()))
            {
                throw new DuplicateNameException("Guid duplicate");
            }

            var job = Jobs[newGuid];
            lock (job)
            {
                job.Task = Task.Factory.StartNew<ulong>(() =>
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
            }

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
    }
}