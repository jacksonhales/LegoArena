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
        public async Task TurnMotorAtPowerAsync(OutputPort outPort, int power)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtPowerAsync(outPort, power);
        }

        public async Task TurnMotorAtSpeedAsync(OutputPort outPort, int speed)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtSpeedAsync(outPort, speed);
        }
        
        public async Task TurnMotorAtPowerForTimeAsync(OutputPort outPort, int power, uint time, bool Bool)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtPowerForTimeAsync(outPort, power, time, Bool);
        }

        public async Task TurnMotorAtSpeedForTimeAsync(OutputPort outPort, int speed, uint time, bool Bool)
        {
            await Controller.TeamBrick.Brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(outPort, speed, time, Bool);
        }

        public async Task StopMotor(OutputPort outPort)
        {
            await Controller.TeamBrick.Brick.DirectCommand.StopMotorAsync(outPort, true);
        }
    }
}
