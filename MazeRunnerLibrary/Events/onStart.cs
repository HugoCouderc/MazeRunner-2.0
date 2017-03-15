using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class OnStart
    {
        string startMessage { get; set; }
        int length { get; set; }
        int width { get; set; }
        string[] players { get; set; }

        public OnStart(string startMessage, int length, int width, string[] nplayers)
        {
            this.startMessage = startMessage;
            this.length = length;
            this.length = width;
            this.players = players;
        }
    }
}
