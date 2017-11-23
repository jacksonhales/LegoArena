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

            Rectangle rectangle = new Rectangle()
            {
                Width = 120,
                Height = 120,
                Fill = Brushes.White,
                Stroke = Brushes.Red,
                StrokeThickness = 2,
                
            };

            cvsArena.Children.Add(rectangle);
            Canvas.SetTop(rectangle, 20);
            Canvas.SetLeft(rectangle, 20);

            //Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new Controller();
            await Controller.TeamBrick.ConnectASync();
            
            Controller.TeamBrick.Brick.BrickChanged += SensorTest;

            /*
             double findcorner = 1;
            double value1 = await controller.FindWall();
            //await controller.TurnLeft90Degree();
            double value2 = await controller.FindWall();

            if (findcorner == 1)
            {
                if (value1 == 4 && value2 == 2)
                {
                    await controller.TurnRightAtDegree(135);
                    await controller.FindWall();
                }
                else if (value1 == 2 && value2 == 4)
                {
                    await controller.TurnLeftAtDegree(135);
                }

                else if (value1 == 5 && value2 == 2)
                {
                    await controller.TurnLeftAtDegree(180);
                    await controller.FindWall();
                }
                else if (value1 == 2 && value2 == 5)
                {
                    await controller.TurnRightAtDegree(90);
                    await controller.FindWall();
                }
                else if (value1 == 4 && value2 == 1)
                {
                    await controller.TurnLeftAtDegree(90);
                    await controller.FindWall();
                }
                else if (value1 == 5 && value2 == 1)
                {
                   
                }
                else if (value1 == 1 && value2 == 5)
                {

                }
            }*/
            
        }

        public async void SensorTest(object sender, BrickChangedEventArgs e)
        {
            GyroValue.Content = controller.GyroSensor.GetValue();
            UltraSonicValue.Content = controller.UltrasonicSensor.GetValue();
            ColourValue.Content = controller.ColourSensor.GetValue();
        }

        private async void FindBlueRed_Click(object sender, RoutedEventArgs e)
        {
            double colourValue = await controller.FindWall();

            // if yellow first
            if (colourValue == 4) 
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if blue, which it should be
                if (colourValue == 2)
                {
                    await controller.TurnRight90Degree();
                    colourValue = await controller.FindWall();
                    // if red, which it should be
                    if (colourValue == 5)
                    {
                        // stop because you're in the red/blue corner
                        Application.Current.Shutdown();
                    }
                }
            }

            // if red first
            else if (colourValue == 5)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if blue, which it should be
                if (colourValue == 2)
                {
                    // stop because you're in the red/blue corner
                    Application.Current.Shutdown();
                }
            }

            // if blue first
            else if (colourValue == 2)
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if red, which it should be
                if (colourValue == 5)
                {
                    // stop because you're in the red/blue corner
                    Application.Current.Shutdown();
                }
            }

            // if black first
            else
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if red, which it should be
                if (colourValue == 5)
                {
                    await controller.TurnLeft90Degree();
                    colourValue = await controller.FindWall();
                    // if blue, which it should be
                    if (colourValue == 2)
                    {
                        // stop because you're in the red/blue corner
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        private async void FindBlueYellow_Click(object sender, RoutedEventArgs e)
        {
            double colourValue = await controller.FindWall();

            // if red first
            if (colourValue == 5)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if blue, which it should be
                if (colourValue == 2)
                {
                    await controller.TurnLeft90Degree();
                    colourValue = await controller.FindWall();
                    // if yellow, which it should be
                    if (colourValue == 4)
                    {
                        // stop because you're in the blue/yellow corner
                        Application.Current.Shutdown();
                    }
                }
            }

            // if yellow first
            else if (colourValue == 4)
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if blue, which it should be
                if (colourValue == 2)
                {
                    // stop because you're in the blue/yellow corner
                    Application.Current.Shutdown();
                }
            }

            // if blue first
            else if (colourValue == 2)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if yellow, which it should be
                if (colourValue == 4)
                {
                    // stop because you're in the blue/yellow corner
                    Application.Current.Shutdown();
                }
            }

            // if black first
            else
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if yellow, which it should be
                if (colourValue == 4)
                {
                    await controller.TurnRight90Degree();
                    colourValue = await controller.FindWall();
                    // if blue, which it should be
                    if (colourValue == 2)
                    {
                        // stop because you're in the blue/yellow corner
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        private async void FindBlackRed_Click(object sender, RoutedEventArgs e)
        {
            double colourValue = await controller.FindWall();

            // if yellow first
            if (colourValue == 4)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if black, which it should be
                if (colourValue == 1)
                {
                    await controller.TurnLeft90Degree();
                    colourValue = await controller.FindWall();
                    // if red, which it should be
                    if (colourValue == 5)
                    {
                        // stop because you're in the black/red corner
                        Application.Current.Shutdown();
                    }
                }
            }

            // if red first
            else if (colourValue == 5)
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if black, which it should be
                if (colourValue == 1)
                {
                    // stop because you're in the black/red corner
                    Application.Current.Shutdown();
                }
            }

            // if black first
            else if (colourValue == 1)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if red, which it should be
                if (colourValue == 5)
                {
                    // stop because you're in the black/red corner
                    Application.Current.Shutdown();
                }
            }

            // if blue first
            else
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if red, which it should be
                if (colourValue == 5)
                {
                    await controller.TurnRight90Degree();
                    colourValue = await controller.FindWall();
                    // if black, which it should be
                    if (colourValue == 1)
                    {
                        // stop because you're in the black/red corner
                        Application.Current.Shutdown();
                    }
                }
            }
        }

        private async void FindBlackYellow_Click(object sender, RoutedEventArgs e)
        {
            double colourValue = await controller.FindWall();

            // if red first
            if (colourValue == 5)
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if black, which it should be
                if (colourValue == 1)
                {
                    await controller.TurnRight90Degree();
                    colourValue = await controller.FindWall();
                    // if yellow, which it should be
                    if (colourValue == 4)
                    {
                        // stop because you're in the black/yellow corner
                        Application.Current.Shutdown();
                    }
                }
            }

            // if yellow first
            else if (colourValue == 4)
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if black, which it should be
                if (colourValue == 1)
                {
                    // stop because you're in the black/yellow corner
                    Application.Current.Shutdown();
                }
            }

            // if black first
            else if (colourValue == 1)
            {
                await controller.TurnRight90Degree();
                colourValue = await controller.FindWall();
                // if yellow, which it should be
                if (colourValue == 4)
                {
                    // stop because you're in the black/yellow corner
                    Application.Current.Shutdown();
                }
            }

            // if blue first
            else
            {
                await controller.TurnLeft90Degree();
                colourValue = await controller.FindWall();
                // if yellow, which it should be
                if (colourValue == 4)
                {
                    await controller.TurnRight90Degree();
                    colourValue = await controller.FindWall();
                    // if black, which it should be
                    if (colourValue == 1)
                    {
                        // stop because you're in the black/yellow corner
                        Application.Current.Shutdown();
                    }
                }
            }
        }
    }
}
