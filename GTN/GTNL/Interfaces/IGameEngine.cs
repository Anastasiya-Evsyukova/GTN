using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Models;

namespace GTNL.Interfaces
{

    //игровой движок.

    public interface IGameEngine
    {

        //начинает новую игру с указанными настройками.

        void StartNewGame(IGameSettings settings);

        //обрабатывает догадку игрока.

        GuessResult Guess(int number);


        //текущее состояние игры

        GameState State { get; }
    }
}
