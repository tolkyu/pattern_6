using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RobotZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Invoker invoker = new Invoker();
            invoker.setCommand(new MoveForwardCommand(robot,20));
            invoker.setCommand(new RotateCommand(robot,90));
            invoker.setCommand(new HandUpCommand(robot,30));
            invoker.Run();
            invoker.Cancel(2);
        }
    }
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class MoveForwardCommand : ICommand
    {
        Robot robot;
        int step;
        public MoveForwardCommand(Robot robot, int step)
        {
            this.robot = robot;
            this.step = step;
        }
        public void Execute()
        {
            robot.MoveForward(step);
        }

        public void Undo()
        {
            robot.MoveForward(-1 * step);
        }
    }
    class RotateCommand : ICommand
    {
        Robot robot;
        int degree;
        public RotateCommand(Robot robot, int degree)
        {
            this.robot = robot;
            this.degree = degree;
        }
        public void Execute()
        {
            robot.Rotate(degree);
        }

        public void Undo()
        {
            robot.Rotate(-1 * degree);
        }
    }
    class HandUpCommand : ICommand
    {
        Robot robot;
        int cm;
        public HandUpCommand(Robot robot, int cm)
        {
            this.robot = robot;
            this.cm = cm;
        }
        public void Execute()
        {
            robot.HandUp(cm);
        }

        public void Undo()
        {
            robot.HandUp(-1 * cm);
        }
    }
    class Invoker
    {
        Queue<ICommand> commandQueue = new Queue<ICommand>();
        Stack<ICommand> commandStack = new Stack<ICommand>();
        public void setCommand(ICommand comand)
        {
            commandQueue.Enqueue(comand);
        }
        public void Run()
        {
            while (commandQueue.Count > 0)
            {
                ICommand command = commandQueue.Dequeue();
                command.Execute();
                commandStack.Push(command);
            }
        }
        public void Cancel(int number)
        {
            while (commandStack.Count > 0 && number > 0)
            {
                ICommand command = commandStack.Pop();
                command.Undo();
                
                number--;
            }

        }
    }


}
