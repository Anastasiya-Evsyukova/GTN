using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;

namespace GTNL.Services.Difficulties
{
    public class HardGameSettings : IGameSettings
    {
        public int MinValue => 1;
        public int MaxValue => 200;
        public int MaxAttempts => 5;
    }
}