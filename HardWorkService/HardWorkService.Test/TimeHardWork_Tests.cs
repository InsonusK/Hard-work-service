using System;
using System.Globalization;
using NUnit.Framework;

namespace HardWorkService.Test
{
    public class TimeHardWork_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Work_TimeSpend()
        {
            // Array
            TimeSpan _span = TimeSpan.FromSeconds(2);
            DateTime dtStart = DateTime.Now;
            DateTime expectedEnd = dtStart.Add(_span).Subtract(TimeSpan.FromMilliseconds(1));
            DateTime expectedEndPlus = expectedEnd.AddMilliseconds(3);

            // Act
            var _return = TimeHardWork.Work(_span);
            DateTime dtEnd = DateTime.Now;

            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(expectedEnd <= dtEnd && dtEnd <= expectedEndPlus);
        }

        [Test]
        public void Work_workUntil()
        {
            // Array
            DateTime _workUntil = DateTime.Now.AddSeconds(2);

            // Act
            var _return = TimeHardWork.Work(_workUntil);
            DateTime dtEnd = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1));
            DateTime dtEndPlus = dtEnd.AddMilliseconds(3);

            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(dtEnd <= _workUntil && _workUntil <= dtEndPlus,
                $"{nameof(_workUntil)} = {_workUntil.ToString(CultureInfo.CurrentCulture)}.{_workUntil.Millisecond}, " +
                $"{nameof(dtEnd)} = {dtEnd.ToString(CultureInfo.CurrentCulture)}.{dtEnd.Millisecond}, " +
                $"{nameof(dtEndPlus)} = {dtEndPlus.ToString(CultureInfo.CurrentCulture)}.{dtEndPlus.Millisecond}");
        }

        [Test]
        public void DoNow_TimeSpend()
        {
            // Array
            TimeSpan _span = TimeSpan.FromSeconds(2);
            DateTime dtStart = DateTime.Now;
            DateTime expectedEnd = dtStart.Add(_span).Subtract(TimeSpan.FromMilliseconds(1));
            DateTime expectedEndPlus = expectedEnd.AddMilliseconds(3);

            // Act
            var _return = new TimeHardWork().DoNow(_span);
            DateTime dtEnd = DateTime.Now;

            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(expectedEnd <= dtEnd && dtEnd <= expectedEndPlus);
        }
    }
}