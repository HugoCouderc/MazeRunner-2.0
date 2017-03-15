using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class OnFinish
    {
        //string congrats { get; set; }
       public string secret { get; set; }

        public OnFinish(string secret)
        {
            //this.congrats = congrats;
            this.secret = secret;
        } 
    }
}
