using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lego;
using Lego.Ev3;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
using System.Diagnostics;

namespace LegoArena.ClassLibrary
{       
    // JACKSONS CODE

    public class Controller
    {
        private static TeamBrick teamBrick;
        private GyroSensor gyroSensor;
        private ColourSensor colourSensor;
        private UltrasonicSensor ultrasonicSensor;
        private Motor motor;

        public static TeamBrick TeamBrick
        {
            get
            {
                return teamBrick;
            }
            set
            {
                teamBrick = value;
            }
        }

        public GyroSensor GyroSensor
        {
            get
            {
                return gyroSensor;
            }
            set
            {
                gyroSensor = value;
            }
        }

        public ColourSensor ColourSensor
        {
            get
            {
                return colourSensor;
            }
            set
            {
                colourSensor = value;
            }
        }

        public UltrasonicSensor UltrasonicSensor
        {
            get
            {
                return ultrasonicSensor;
            }
            set
            {
                ultrasonicSensor = value;
            }
        }

        public Motor Motor
        {
            get
            {
                return motor;
            }
            set
            {
                motor = value;
            }
        }

        public Controller()
        {
            teamBrick = new TeamBrick();
            ultrasonicSensor = new UltrasonicSensor();
            gyroSensor = new GyroSensor();
            colourSensor = new ColourSensor();
            motor = new Motor();
            
        }
        
        public async void FindWall()
        {
            while (UltrasonicSensor.sensorValue <= 10)
            {
                await Motor.TurnMotorAtPowerForTimeAsync(OutputPort.A | OutputPort.D, 50, 1000, true); 
                await Task.Delay(2000);
            }
        }

        public async void TurnLeft()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue > originalGyroValue - 90)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -40, 80, true);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 40, 80, true);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(100);
            }
        }

        public async void TurnRight()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue > originalGyroValue + 90)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 40, 80, true);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -40, 80, true);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(100);
            }
        }

        public async void TurnAround()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue > originalGyroValue - 180)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -40, 80, true);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 40, 80, true);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(100);
            }
        }
    }
}
