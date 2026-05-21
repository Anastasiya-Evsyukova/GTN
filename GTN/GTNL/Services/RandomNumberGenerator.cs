using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;

namespace GTNL.Services
{
    public class RandomNumberGenerator : INumberGenerator
    {
        private readonly Random _random = new Random();

        public int Generate(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }
    }
}