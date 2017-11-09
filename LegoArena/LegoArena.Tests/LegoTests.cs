using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using LegoArena.ClassLibrary;
using System.Threading.Tasks;

namespace LegoArena.Tests
{
    [TestClass]
    public class LegoTests
    {
        [TestMethod]
        public async Task TestBrickConnect()
        {
            // assert
            await Controller.TeamBrick.ConnectASync();
        }
    }
}
