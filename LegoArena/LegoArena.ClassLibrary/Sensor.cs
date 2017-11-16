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
    public abstract class Sensor
    {
        public InputPort sensorPort;

        public float sensorValue;

        public Sensor()
        {
            Controller.TeamBrick.Brick.BrickChanged += Brick_BrickChanged;
        }

        public async void Brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            //sensorValue = await Controller.TeamBrick.Brick.DirectCommand.ReadySIAsync(sensorPort, 0);
            sensorValue = e.Ports[sensorPort].SIValue;
        }

        public float GetValue()
        {
            return sensorValue;
        }
    }
}
