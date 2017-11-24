using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoArena.ClassLibrary
{
    class Sequences
    {
        Controller controller;

        private async Task sequence()
        {
            /*
            int loop = 0;
            while (loop < 3)
            {
                int corner1, corner2, corner3, corner4, colour1, colour2 = 0;

                loop++;
                if (loop == 1)
                {
                    int corner1 = 5;
                    int corner2 = 2;
                    int corner3 = 4;
                    int corner4 = 3;
                }

                double colourValue = await controller.FindWall();

                int passed = 0;
                while (passed == 0)
                {
                    int colour1 = Convert.ToInt32(colourValue);
                    while (colour1 == Convert.ToInt32(colourValue))
                    {
                        await controller.TurnRight45Degree();
                    }

                    double colourValue = await controller.FindWall();

                    int colour2 = Convert.ToInt32(colourValue);
                    if (colour1 != colour2)
                    {
                        passed = 1;
                    }
                }

                int found = 0;

                if ((colour1 == corner1 && colour2 == corner2) || (corner1 == corner2 && colour2 == corner1))
                {
                    found = 1;
                }

                if ((colour1 == corner1 && colour2 == corner4) || (corner1 == corner4 && colour2 == corner1))
                {
                    if (colour1 == corner1)
                    {
                        await controller.TurnAround();
                    }
                    else if (colour1 == corner4)
                    {
                        await controller.TurnLeft90Degree();
                    }

                    colourValue = await controller.FindWall();

                    while (colour1 != corner2 && colour2 != corner1)
                    {
                        if (colourValue == corner2)
                        {
                            colour1 = corner2;
                            await controller.TurnRight90Degree();
                            colourValue = await controller.FindWall();
                        }
                        if (colourValue == corner1)
                        {
                            colour2 = corner1;
                            await controller.TurnLeft90Degree();
                            colourValue = await controller.FindWall();
                        }
                    }
                    found = 1;
                    */
                }
                
            }
        }
  
