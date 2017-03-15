using MazeRunnerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerRunner
{
    class Program
    {

        static void Main(string[] args)
        {

            bool choiceMade = false;
            MazeRunnerLib.SuperRunner runner =null;

            while (!choiceMade)
            {
                Console.WriteLine("Choose your Hero !");
                Console.WriteLine("");

                Console.WriteLine("1 - EagleEye");
                Console.WriteLine("2 - QuickFlash");
                Console.WriteLine("3 - the Ghost");
                Console.WriteLine("4 - Duplicata");

                Console.WriteLine("");

                string choice = Console.ReadLine();
                int choice2 = Convert.ToInt32(choice);

                switch (choice2)
                {
                    case 1:
                        runner = new MazeRunnerLib.EagleRunner();
                        choiceMade = true;
                        break;

                    case 2:
                        runner = new MazeRunnerLib.SpeedRunner();
                        choiceMade = true;
                        break;

                    case 3:
                        runner = new MazeRunnerLib.WallRunner();
                        choiceMade = true;
                        break;

                    case 4:
                        runner = new MazeRunnerLib.SuperRunner();
                        choiceMade = true;
                        break;
                    default:
                        Console.WriteLine("Input was not recognised, please try again");
                        break;
                }
            }
       

            runner.onMove += Runner_onMove;

            runner.onFinish += Runner_onFinish;


            Thread thread = new Thread(() => runner.playerThreadFunction());
            thread.Start();

        }

        private static void Runner_onMove(object sender, OnMove move)
        {
            Console.WriteLine("player moved " + move.lastMove);
            Console.WriteLine("new position ==> " + move.newPosition);
        }

        private static void Runner_onFinish(object sender, OnFinish fin)
        {
            Console.WriteLine("Congratulations on finishing the level !");

            Console.WriteLine("player moved " + fin.secret);

        }
    }
}
