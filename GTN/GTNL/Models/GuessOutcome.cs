using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTNL.Models
{
    public enum GuessOutcome
    {
        Less, //БОЛЬШЕ введенного
        Greater, //МЕНЬШЕ введенного 
        Equal,
        GameOver,
        Invalid
    }
}