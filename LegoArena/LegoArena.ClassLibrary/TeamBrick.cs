using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego;
using Lego.Ev3;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
using System.Diagnostics;

namespace LegoArena.ClassLibrary
{
    public class TeamBrick
    {
        Brick brick;

        public TeamBrick()
        {
            brick = new Brick(new UsbCommunication());
        }
    }
}
