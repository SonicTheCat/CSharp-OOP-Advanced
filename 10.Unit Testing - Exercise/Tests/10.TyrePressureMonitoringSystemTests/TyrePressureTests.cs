using NUnit.Framework;
using Moq;
using System;
using TDDMicroExercises.TirePressureMonitoringSystem;
using System.Reflection;
using System.Linq;
using TyrePressureMonitoringSystem.Contracts;

namespace Tests.TyrePressureMonitoringSystemTests
{
    public class TyrePressureTests
    {
        private const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

        private Type alarmType = typeof(Alarm);
        private Type sensorType = typeof(ISensor);

        private Mock<ISensor> fakeSensor;

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            this.fakeSensor = new Mock<ISensor>();
        }

        [Test]
        public void AlarmDefaultValue_ShouldBeFalse()
        {
            var alarmInstance = GetAlarmInstance();

            Assert.That(alarmInstance.AlarmOn, Is.False);
        }

        [TestCase(17.0)]
        [TestCase(17.1)]
        [TestCase(17.01)]
        [TestCase(21)]
        [TestCase(20.9)]
        [TestCase(20)]
        [TestCase(19.5)]
        public void AlarmIsOff_ShouldReturnFalse(double value)
        {
            fakeSensor
                .Setup(x => x.PopNextPressurePsiValue())
                .Returns(value);

            var field = GetSensorField();
            var alarmInstance = GetAlarmInstance();

            field.SetValue(alarmInstance, fakeSensor.Object);

            Assert.That(alarmInstance.AlarmOn, Is.False);
            alarmInstance.Check();
            Assert.That(alarmInstance.AlarmOn, Is.False);
        }

        [TestCase(16.9)]
        [TestCase(-17)]
        [TestCase(16.0)]
        [TestCase(21.0001)]
        [TestCase(21.5)]
        [TestCase(100)]
        [TestCase(0)]
        public void AlarmIsOn_ShouldReturnTrue(double value)
        {
            fakeSensor
              .Setup(x => x.PopNextPressurePsiValue())
              .Returns(value);

            var field = GetSensorField();
            var alarmInstance = GetAlarmInstance();

            field.SetValue(alarmInstance, fakeSensor.Object);

            Assert.That(alarmInstance.AlarmOn, Is.False);
            alarmInstance.Check();
            Assert.That(alarmInstance.AlarmOn, Is.True);
        }

        private FieldInfo GetSensorField()
        {
            return alarmType
                .GetFields(flags)
                .FirstOrDefault(f => f.FieldType == sensorType);
        }

        private Sensor GetSensorInstance()
        {
            return (Sensor)Activator.CreateInstance(sensorType, null);
        }

        private Alarm GetAlarmInstance()
        {
            return (Alarm)Activator.CreateInstance(alarmType, null);
        }
    }
}