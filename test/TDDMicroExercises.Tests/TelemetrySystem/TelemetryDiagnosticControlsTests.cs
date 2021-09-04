using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TDDMicroExercises.TelemetrySystem;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.Tests.TelemetrySystem
{
    [TestClass]
    public class TelemetryDiagnosticControlsTests
    {
        [TestMethod]
        public void When_Connect_Fails_Then_Throw_Exception()
        {
            //arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            var underTest = new TelemetryDiagnosticControls(mockTelemetryClient.Object);


            //assert
            Assert.ThrowsException<Exception>(() => underTest.CheckTransmission());
            mockTelemetryClient.Verify(x => x.Connect(null), Times.Exactly(3));
            mockTelemetryClient.Verify(x => x.Disconnect(), Times.Once);
            mockTelemetryClient.Verify(x => x.Send(It.IsAny<string>()), Times.Never);
            mockTelemetryClient.Verify(x => x.Receive(), Times.Never);

        }

        [TestMethod]
        public void When_Connect_Succeeds_Then_Throw_Exception()
        {
            //arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(x => x.OnlineStatus).Returns(true);
            mockTelemetryClient.Setup(x => x.Receive()).Returns("new message");
            var underTest = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            //act
            underTest.CheckTransmission();

            //assert
            Assert.AreEqual("new message", underTest.DiagnosticInfo);
            mockTelemetryClient.Verify(x => x.Disconnect(), Times.Once);
            mockTelemetryClient.Verify(x => x.Send(It.IsAny<string>()), Times.Once);
            mockTelemetryClient.Verify(x => x.Receive(), Times.Once);
            mockTelemetryClient.Verify(x => x.DiagnosticMessage, Times.Once);


        }
    }
}
