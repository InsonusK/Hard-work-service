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

            // Act
            var _return = TimeHardWork.Work(_span);
            DateTime dtEnd = DateTime.Now;
            
            DateTime expectedEnd = dtStart.Add(_span).Subtract(TimeSpan.FromMilliseconds(1));
            DateTime expectedEndPlus = expectedEnd.AddMilliseconds(30);

            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(expectedEnd <= dtEnd && dtEnd <= expectedEndPlus,
                $"{nameof(dtEnd)} = {dtEnd.ToString(CultureInfo.CurrentCulture)}.{dtEnd.Millisecond}, " +
                $"{nameof(expectedEnd)} = {expectedEnd.ToString(CultureInfo.CurrentCulture)}.{expectedEnd.Millisecond}, " +
                $"{nameof(expectedEndPlus)} = {expectedEndPlus.ToString(CultureInfo.CurrentCulture)}.{expectedEndPlus.Millisecond}");
        }

        [Test]
        public void Work_workUntil()
        {
            // Array
            DateTime _workUntil = DateTime.Now.AddSeconds(2);

            // Act
            var _return = TimeHardWork.Work(_workUntil);
            DateTime expectedEnd = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1));
            DateTime expectedEndPlus = _workUntil.AddMilliseconds(20);

            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(expectedEnd <= _workUntil && _workUntil <= expectedEndPlus,
                $"{nameof(_workUntil)} = {_workUntil.ToString(CultureInfo.CurrentCulture)}.{_workUntil.Millisecond}, " +
                $"{nameof(expectedEnd)} = {expectedEnd.ToString(CultureInfo.CurrentCulture)}.{expectedEnd.Millisecond}, " +
                $"{nameof(expectedEndPlus)} = {expectedEndPlus.ToString(CultureInfo.CurrentCulture)}.{expectedEndPlus.Millisecond}");
        }

        [Test]
        public void DoNow_TimeSpend()
        {
            // Array
            TimeSpan _span = TimeSpan.FromSeconds(2);
            DateTime dtStart = DateTime.Now;
            
            // Act
            var _return = new TimeHardWork().DoNow(_span);
            DateTime dtEnd = DateTime.Now;

            DateTime expectedEnd = dtStart.Add(_span).Subtract(TimeSpan.FromMilliseconds(1));
            DateTime expectedEndPlus = expectedEnd.AddMilliseconds(30);
            
            // Assert
            Assert.IsNotNull(_return);
            Assert.IsTrue(expectedEnd <= dtEnd && dtEnd <= expectedEndPlus,
                $"{nameof(dtEnd)} = {dtEnd.ToString(CultureInfo.CurrentCulture)}.{dtEnd.Millisecond}, " +
                $"{nameof(expectedEnd)} = {expectedEnd.ToString(CultureInfo.CurrentCulture)}.{expectedEnd.Millisecond}, " +
                $"{nameof(expectedEndPlus)} = {expectedEndPlus.ToString(CultureInfo.CurrentCulture)}.{expectedEndPlus.Millisecond}");
        }
    }
}