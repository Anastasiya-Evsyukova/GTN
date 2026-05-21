using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;

namespace GTNL.Services.Difficulties
{
    public class EasyGameSettings : IGameSettings //реализует интерфейс IGameSettings 
    {
        public int MinValue => 1; //лямбда-свойство, всегда возвращает 1
        public int MaxValue => 50;
        public int MaxAttempts => 10;
    }
}