using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego;
using Lego.Ev3;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;

namespace LegoArena.ClassLibrary
{
    public class UltrasonicSensor : Sensor
    {
        public UltrasonicSensor()
        {
            this.sensorPort = InputPort.Three;
        }
    }
}
