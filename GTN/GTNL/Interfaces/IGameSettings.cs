using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTNL.Interfaces
{

    //параметры уровня сложности
    public interface IGameSettings
    {
        int MinValue { get; }
        int MaxValue { get; }
        int MaxAttempts { get; }
    }
}