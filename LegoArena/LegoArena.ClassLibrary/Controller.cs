using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego;
using Lego.Ev3;
using Lego.Ev3.Desktop;

namespace LegoArena.ClassLibrary
{       
    // JACKSONS CODE

    class Controller
    {
        Brick brick;
        GyroSensor gyroSensor;
        ColourSensor colourSensor;
        UltrasonicSensor ultrasonicSensor;
        Movement movement;
        Motor motor;

        public Controller()
        {
            brick = new Brick();
            gyroSensor = new GyroSensor();
            colourSensor = new ColourSensor();
            ultrasonicSensor = new UltrasonicSensor();
            movement = new Movement();
            motor = new Motor();
        }
    }
}
