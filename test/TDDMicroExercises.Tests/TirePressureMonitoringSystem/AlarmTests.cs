using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.Tests.TirePressureMonitoringSystem
{
    [TestClass]
    public class AlarmTests
    {

        [TestMethod]
        public void When_Low_Pressure_Then_Alarm_On()
        {
            //arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(10);
            var underTest = new Alarm(mockSensor.Object);
            
            //act
            underTest.Check();

            //assert
            Assert.IsTrue(underTest.AlarmOn);
            mockSensor.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
        }

        [TestMethod]
        public void When_High_Pressure_Then_Alarm_On()
        {
            //arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(25);
            var underTest = new Alarm(mockSensor.Object);

            //act
            underTest.Check();

            //assert
            Assert.IsTrue(underTest.AlarmOn);
            mockSensor.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
        }

        [TestMethod]
        public void When_Normal_Pressure_Then_Alarm_Off()
        {
            //arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(18);
            var underTest = new Alarm(mockSensor.Object);

            //act
            underTest.Check();

            //assert
            Assert.IsFalse(underTest.AlarmOn);
            mockSensor.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
        }
    }
}
