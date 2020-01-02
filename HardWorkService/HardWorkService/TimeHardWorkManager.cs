using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using HardWorkService.Interface;
using HardWorkService.Models;

namespace HardWorkService
{
    public class TimeHardWorkManager : IHardWorkServiceManager
    {
        private readonly ConcurrentDictionary<Guid, Result> _dictionary;

        public TimeHardWorkManager(ConcurrentDictionary<Guid, Result> dictionary)
        {
            _dictionary = dictionary;
        }

        #region Implementation of IHardWorkServiceManager

        /// <inheritdoc />
        public int JobsCount(bool onlyOpen = true)
        {
            return !onlyOpen
                ? _dictionary.Count
                : _dictionary.Where(kvp => !kvp.Value.Finish).Select(kvp => kvp.Key).ToList().Count;
        }

        /// <inheritdoc />
        public IReadOnlyDictionary<Guid, IReadResult> GetJobs()
        {
            return new Dictionary<Guid, IReadResult>(_dictionary.ToDictionary(kvp => kvp.Key,
                kvp => (IReadResult) kvp.Value));
        }

        /// <inheritdoc />
        public bool RemoveJob(params Guid[] guid)
        {
            bool _return = false;
            foreach (Guid _guid in guid)
            {
                if (_dictionary.TryRemove(_guid, out var _value)) _return = true;
            }

            return _return;
        }

        /// <inheritdoc />
        public void RemoveEndedJobs()
        {
            var removingList = _dictionary.Where(kvp => kvp.Value.Finish).Select(kvp => kvp.Key).ToArray();
            RemoveJob(removingList);
        }

        #endregion
    }
}