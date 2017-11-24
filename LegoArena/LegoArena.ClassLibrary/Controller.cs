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
            await Task.Delay(100);
            int count = 0;
            //List<float> wallValues = new List<float>();
            float originalGyroValue = GyroSensor.GetValue();
<<<<<<< HEAD
            while (UltrasonicSensor.sensorValue >= 4) 
=======
            while (UltrasonicSensor.GetValue() >= 5) 
>>>>>>> c102f27d2ef30024b9ea6172365da5d704645efb
            {
                if (GyroSensor.GetValue() < originalGyroValue - 7) //check if vehicle has turned more than 7 degrees off of original orientation
                {
                    await TurnRightAtDegree(originalGyroValue - GyroSensor.GetValue()); //turn right to center back to original orientation
                    await DriveStraight();
                }
                if (GyroSensor.GetValue() > originalGyroValue + 7) //check if vehicle has turned more than 7 degrees off of original orientation
                {
                    await TurnLeftAtDegree(GyroSensor.GetValue() - originalGyroValue); // turn left to center back to original orientation
                    await DriveStraight();
                }
                else
                {
<<<<<<< HEAD
                 /*   if (colourSensor.sensorValue != 0)
                    {
                        wallValues.Add(colourSensor.GetValue());
                        count++;
                    }*/
=======

>>>>>>> c102f27d2ef30024b9ea6172365da5d704645efb
                    await DriveStraight();
                    await Task.Delay(10);
                }
                
            }
            return colourSensor.sensorValue;
        }

        public async Task<double> ScanWall()
        {
            await Task.Delay(200);
            List<float> wallValues = new List<float>();
            float originalGyroValue = gyroSensor.sensorValue;

            while (GyroSensor.GetValue() >= originalGyroValue - 30)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -50, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 50, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                wallValues.Add(ColourSensor.sensorValue);
                await Task.Delay(13);
            }
            while (GyroSensor.GetValue() <= originalGyroValue + 30)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 50, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -50, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                wallValues.Add(ColourSensor.sensorValue);
                await Task.Delay(13);
            }
            while (GyroSensor.GetValue() >= originalGyroValue)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -50, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 50, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                wallValues.Add(ColourSensor.sensorValue);
                await Task.Delay(13);
            }
            var return1 = Math.Round(wallValues.Average(),0);
            return return1;
        }

        public async Task TurnLeft90Degree()
        {
            
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.GetValue();

            while (gyroSensor.GetValue() >= originalGyroValue - 90)
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
            float originalGyroValue = GyroSensor.GetValue();

            while (gyroSensor.GetValue() <= originalGyroValue + 90)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task TurnLeft45Degree()
        {

            await Task.Delay(100);
            float originalGyroValue = GyroSensor.GetValue();

            while (gyroSensor.GetValue() >= originalGyroValue - 45)
            {

                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }

        public async Task TurnRight45Degree()
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.GetValue();

            while (gyroSensor.GetValue() <= originalGyroValue + 45)
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
            float originalGyroValue = GyroSensor.GetValue();

            while (gyroSensor.GetValue() >= originalGyroValue - 180)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -27, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 27, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
        public async Task DriveStraight()
        {
            TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A | OutputPort.D, 60, 10, false);
            await TeamBrick.Brick.BatchCommand.SendCommandAsync();
            await Task.Delay(10);
        }
        public async Task TurnLeftAtDegree(float degreeToTurn)
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.GetValue();

            while (GyroSensor.GetValue() >= originalGyroValue - degreeToTurn)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -37, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 37, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
        public async Task TurnRightAtDegree(float degreeToTurn)
        {
            await Task.Delay(100);
            float originalGyroValue = GyroSensor.GetValue();

            while (GyroSensor.GetValue() <= originalGyroValue + degreeToTurn)
            {
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 37, 10, false);
                TeamBrick.Brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -37, 10, false);
                await TeamBrick.Brick.BatchCommand.SendCommandAsync();
                await Task.Delay(10);
            }
        }
    }
}
