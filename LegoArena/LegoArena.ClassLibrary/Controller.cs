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
    // Everyones code

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
        
        public async Task<double> FindWall()
        {
            List<int> wallValues = new List<int>();
            await Task.Delay(100);

            while (UltrasonicSensor.sensorValue >= 5)
            {
                await DriveStraight();
                if (ColourSensor.sensorValue != 0)
                {
                    wallValues.Add((int)ColourSensor.sensorValue);
                }
            }
            return wallValues.Average();
        }

        public async Task TurnLeft90Degree()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue >= originalGyroValue - 90)
            {
                
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task TurnRight90Degree()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            var value = await TeamBrick.Brick.DirectCommand.ReadySIAsync(InputPort.One, 0);

            while (value <= originalGyroValue + 90)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task TurnAround()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue >= originalGyroValue - 180)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
        public async Task DriveStraight()
        {
            TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A | OutputPort.D, 27, 10, false);
            await TeamBrick.Brick.BatchCommand.SendCommandAsync();
            await Task.Delay(10);
        }
        public async Task TurnLeftAtDegree(float degreeToTurn)
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue <= originalGyroValue - degreeToTurn)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
        public async Task TurnRightAtDegree(float degreeToTurn)
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.sensorValue;

            while (GyroSensor.sensorValue <= originalGyroValue - degreeToTurn)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
    }
}
