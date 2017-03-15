using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class OnMove
    {
        public string lastMove { get; set; }
        public string newPosition { get; set;}
        
        public OnMove(string lastMove, string newPosition)
        {
            this.lastMove = lastMove;
            this.newPosition = newPosition;
        }
    }
}
