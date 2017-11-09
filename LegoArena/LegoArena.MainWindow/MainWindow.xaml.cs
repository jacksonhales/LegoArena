using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LegoArena.ClassLibrary;
using Lego.Ev3.Core;

namespace LegoArena.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;

        public MainWindow()
        {
            InitializeComponent();
            
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new Controller();
            await Controller.TeamBrick.ConnectASync();
            
            Controller.TeamBrick.Brick.BrickChanged += SensorTest;

            TestMotors();
        }

        public async void SensorTest(object sender, BrickChangedEventArgs e)
        {
            GyroValue.Content = controller.GyroSensor.GetValue();
            UltraSonicValue.Content = controller.UltrasonicSensor.GetValue();
            ColourValue.Content = controller.ColourSensor.GetValue();
        }

        public async void TestMotors()
        {
            await controller.Motor.TurnMotorAtPowerForTimeAsync(OutputPort.A, 100, 1000, false);
            await controller.Motor.TurnMotorAtPowerForTimeAsync(OutputPort.D, 100, 1000, false);
        }
    }
}
