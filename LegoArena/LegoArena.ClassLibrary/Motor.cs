using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego;
using Lego.Ev3;
using Lego.Ev3.Core;
namespace LegoArena.ClassLibrary
{
    //Dylan's Code
    public class Motor
    {
        public async void TurnMotorAtPowerAsync(OutputPort outPort, int power)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtPowerAsync(outPort, power);
        }

        public async void TurnMotorAtSpeedAsync(OutputPort outPort, int speed)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtSpeedAsync(outPort, speed);
        }
        
        public async void TurnMotorAtPowerForTimeAsync(OutputPort outPort, int power, uint time, bool Bool)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(outPort, power, time, Bool);
        }

        public async void TurnMotorAtSpeedForTimeAsync(OutputPort outPort, int speed, uint time, bool Bool)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(outPort, speed, time, Bool);
        }
        /*public async void Brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {

        }*/
    }
    

}
