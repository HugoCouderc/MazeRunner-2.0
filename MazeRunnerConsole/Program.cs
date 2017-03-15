using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeRunnerLibrary;
using MazeRunnerLib;
using System.Threading;

namespace MazeRunnerConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            MazeRunnerLib.Runner runner = new MazeRunnerLib.Runner();

            runner.onMove += Runner_onMove;

            runner.onFinish += Runner_onFinish;


            Thread thread = new Thread(() => runner.playerThreadFunction());
            thread.Start();


        }

        private static void Runner_onMove(object sender,OnMove move)
        {
            Console.WriteLine("player moved "+ move.lastMove);
            Console.WriteLine("new position ==> " + move.newPosition);
        }

        private static void Runner_onFinish(object sender, OnFinish fin)
        {
            Console.WriteLine("Congratulations on finishing the level !");

            Console.WriteLine("player moved " + fin.secret);
            
        }
    }
}
