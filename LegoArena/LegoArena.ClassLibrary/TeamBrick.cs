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
        public Brick brick;

        public Brick Brick
        {
            get
            {
                return brick;
            }
            set
            {
                brick = value;
            }
        }
        
        public void ConnectASync()
        {
            try
            {
                brick = new Brick(new UsbCommunication());
                brick.ConnectAsync();
            }
            catch (Exception)
            {
                throw new Exception("Brick connection error.");
            }
        }

        public void OnBrickChanged(object sender, BrickChangedEventArgs e)
        {

        }
    }
}
