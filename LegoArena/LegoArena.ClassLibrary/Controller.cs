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

    class Controller
    {
        static public TeamBrick teamBrick;
        GyroSensor gyroSensor;
        ColourSensor colourSensor;
        UltrasonicSensor ultrasonicSensor;
        Movement movement;
        Motor motor;

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
