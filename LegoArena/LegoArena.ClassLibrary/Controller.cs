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
        private Movement movement;
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

        public Movement Movement
        {
            get
            {
                return movement;
            }
            set
            {
                movement = value;
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
            gyroSensor = new GyroSensor();
            colourSensor = new ColourSensor();
            ultrasonicSensor = new UltrasonicSensor();
            movement = new Movement();
            motor = new Motor();

            teamBrick.ConnectASync();
        }



    }
}
