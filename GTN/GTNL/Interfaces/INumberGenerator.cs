using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTNL.Interfaces
{

    //генератор случайных чисел

    public interface INumberGenerator
    {
        int Generate(int minValue, int maxValue);
    }
}
