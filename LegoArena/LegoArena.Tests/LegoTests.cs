using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using LegoArena.ClassLibrary;
using System.Threading.Tasks;

namespace LegoArena.Tests
{
    [TestClass]
    public class LegoTests
    {
        [TestMethod]
        public async Task TestBrickConnect()
        {
            // assert
            await Controller.TeamBrick.ConnectASync();
        }

        [TestMethod]
        public async Task TestMotorSpin()
        {
            // arrange
            Controller testController = new Controller();
            
            // act


            // assert
            await testController.Motor.TurnMotorAtPowerForTimeAsync(OutputPort.A, 100, 1000, false);
        }

        [TestMethod]
        public void TestColourSensor()
        {
            // arrange
            Controller testController = new Controller();

            // act
            float testValue = testController.ColourSensor.GetValue();

            // assert
            Assert.IsTrue(testValue > 0 && testValue < 255);

        }

        [TestMethod]
        public void TestGyroSensor()
        {
            // arrange
            Controller testController = new Controller();

            // act
            float testValue = testController.GyroSensor.GetValue();

            // assert
            Assert.IsTrue(testValue > 0 && testValue < 255);

        }

        [TestMethod]
        public void TestUltrasonicSensor()
        {
            // arrange
            Controller testController = new Controller();

            // act
            float testValue = testController.UltrasonicSensor.GetValue();

            // assert
            Assert.IsTrue(testValue > 0 && testValue < 255);

        }
    }
}
