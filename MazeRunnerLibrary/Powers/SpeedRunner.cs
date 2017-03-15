using MazeRunnerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunnerLib
{
    public class SpeedRunner : SuperRunner
    {
        public override int cooldown { get { return 250; } }

        public override MazeRunnerLibrary.PowerRunner.Power power { get { return MazeRunnerLibrary.PowerRunner.Power.SpeedUp; } }

    }
}
