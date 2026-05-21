using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;

namespace GTNL.Services.Difficulties
{
    public class MediumGameSettings : IGameSettings
    {
        public int MinValue => 1;
        public int MaxValue => 100;
        public int MaxAttempts => 7;
    }
}
