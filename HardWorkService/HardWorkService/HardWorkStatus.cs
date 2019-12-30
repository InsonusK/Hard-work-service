using System;
using System.Collections.Generic;

namespace HardWorkService
{
    public class HardWorkStatus
    {
        private readonly IReadOnlyDictionary<Guid, IReadResult> _readOnlyDictionary;

        /// <inheritdoc />
        public HardWorkStatus(IReadOnlyDictionary<Guid, IReadResult> readOnlyDictionary)
        {
            _readOnlyDictionary = readOnlyDictionary;
        }

        public int CountInWork => _readOnlyDictionary.Count;
    }
}