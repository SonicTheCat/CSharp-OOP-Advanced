using System;
using DateTimeNow.Contracts;
using Moq;
using NUnit.Framework;

namespace Tests.DateTimeNowTests
{
    public class DateTimeTest
    {
        private const string errorMonthMessage = "Adding days does not change month value";
        private const string errorDateMessage = "Adding days does not change date value";

        private Mock<IDateTimeHelper> fakeDateTime;

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            this.fakeDateTime = new Mock<IDateTimeHelper>();
        }

        [Test]
        public void DateTimeNow_ShoudPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(DateTime.Now);

            var actual = DateTime.Now.ToShortDateString();
            var expectedResult = this.fakeDateTime.Object.Now.ToShortDateString();
            var errorMessage = $"Method do not return correct values! Expected {actual} to be equal to {expectedResult}";

            Assert.That(actual, Is.EqualTo(expectedResult), errorMessage);
        }

        [Test]
        public void DateTime_ComparedWithDiffrentDate_ShouldThrow()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2000, 10, 12));

            var actual = DateTime.Now.ToShortDateString();
            var expectedResult = this.fakeDateTime.Object.Now.ToShortDateString();
            var errorMessage = $"Expected {actual} to be NOT equal to {expectedResult}";

            Assert.That(actual, Is.Not.EqualTo(expectedResult), errorMessage);
        }

        [Test]
        public void Adding_OneDay_ShouldIncreaseDateTime()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2018, 10, 25));

            var newDateTime = fakeDateTime.Object.Now.AddDays(1);

            var actual = newDateTime.ToShortDateString();
            var expected = 26;
            var oldValue = this.fakeDateTime.Object.Now.ToShortDateString();
            var errorMessage = $"Adding one day does not change the date! Expected {expected} to equals {actual}";

            Assert.That(newDateTime.Day, Is.EqualTo(expected), errorMessage);
            Assert.That(actual, Is.Not.EqualTo(oldValue), errorMessage);
        }

        [Test]
        public void Adding_ChangeTheMonth_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2018, 11, 30));

            var newDateTime = fakeDateTime.Object.Now.AddDays(1);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 12;
            var actualDate = newDateTime.Day;
            var expectedDate = 1;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Adding_NegativeValue_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2018, 11, 30));

            var newDateTime = fakeDateTime.Object.Now.AddDays(-1);

            var actualDate = newDateTime.Day;
            var expectedDate = 29;

            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Adding_NegativeValueChangeMonth_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2018, 11, 15));

            var newDateTime = fakeDateTime.Object.Now.AddDays(-30);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 10;
            var actualDate = newDateTime.Day;
            var expectedDate = 16;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Adding_ToLeapYear_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(2008, 02, 28));

            var newDateTime = fakeDateTime.Object.Now.AddDays(1);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 2;
            var actualDate = newDateTime.Day;
            var expectedDate = 29;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Adding_ToNonLeapYearChangeMonth_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(new DateTime(1900, 02, 28));

            var newDateTime = fakeDateTime.Object.Now.AddDays(1);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 3;
            var actualDate = newDateTime.Day;
            var expectedDate = 1;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Adding_ToMaxValue_ShouldThrow()
        {
            fakeDateTime.Setup(d => d.Now).Returns(DateTime.MaxValue);

            var errorMessage = "Adding to max value does not throw exception!";

            Assert.Throws<ArgumentOutOfRangeException>(() => fakeDateTime.Object.Now.AddDays(1), errorMessage);
        }

        [Test]
        public void Subtract_FromMinValue_ShouldThrow()
        {
            fakeDateTime.Setup(d => d.Now).Returns(DateTime.MinValue);

            var errorMessage = "Subtract from min value does not throw exception!";

            Assert.Throws<ArgumentOutOfRangeException>(() => fakeDateTime.Object.Now.AddDays(-1), errorMessage);
        }

        [Test]
        public void Adding_ToMinValue_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(DateTime.MinValue);

            var newDateTime = fakeDateTime.Object.Now.AddDays(1);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 1;
            var actualDate = newDateTime.Day;
            var expectedDate = 2;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }

        [Test]
        public void Subtract_FromMaxValue_ShouldPass()
        {
            fakeDateTime.Setup(d => d.Now).Returns(DateTime.MaxValue);

            var newDateTime = fakeDateTime.Object.Now.AddDays(-1);

            var actualMonth = newDateTime.Month;
            var expectedMonth = 12;
            var actualDate = newDateTime.Day;
            var expectedDate = 30;

            Assert.That(actualMonth, Is.EqualTo(expectedMonth), errorMonthMessage);
            Assert.That(actualDate, Is.EqualTo(expectedDate), errorDateMessage);
        }
    }
}