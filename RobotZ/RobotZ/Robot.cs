using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RobotZ
{
    class Robot
    {
        public void MoveForward(int step)
        {
            if (step > 0)
            {
                WriteLine($"\tRobot made {step} steps forward.");
            }
            else
            {
                WriteLine($"\tRobot made {-1 * step} steps back.");
            }
        }
        public void Rotate(int degree)
        {
            if (degree > 0)
            {
                WriteLine($"\tRobot rotated {degree} degree.");
            }
            else
            {
                WriteLine($"\tRobot rotated {-1 * degree} degree.");
            }
        }
        public void HandUp(int cm)
        {
            if (cm > 0)
            {
                WriteLine($"\tRobot up hands to {cm} cm.");
            }
            else
            {
                WriteLine($"\tRobot down hands to {-1 * cm} cm.");
            }
        }
    }
}
