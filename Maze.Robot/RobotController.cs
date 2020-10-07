using Maze.Library;
using System;

namespace Maze.Solver
{
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController
    {
        private readonly IRobot robot;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            var reachedEnd = false;
            robot.ReachedExit += (_, __) => reachedEnd = true;
            Random rnd = new Random();
            int moves = 0;
            while (!reachedEnd)
            {
                robot.TryMove((Direction)rnd.Next(0, 4));

                moves++;
                if (moves == 10000000)
                {
                    robot.HaltAndCatchFire();
                    break;
                }
            }
        }

        //bool reachedEnd = false;


        /*public void MakeAMove(Direction? whereICameFrom)
        {
            
            if (reachedEnd) return;

            if (robot.TryMove(Direction.Up) && whereICameFrom != Direction.Down)
            {
                MakeAMove(Direction.Down);
            }
            else if (robot.TryMove(Direction.Right) && whereICameFrom != Direction.Left)
            {
                MakeAMove(Direction.Left);
            }
            else if (robot.TryMove(Direction.Down) && whereICameFrom != Direction.Up)
            {
                MakeAMove(Direction.Up);
            }
            else if (robot.TryMove(Direction.Left) && whereICameFrom != Direction.Right)
            {
                MakeAMove(Direction.Right);
            }
        }*/
    }
}
