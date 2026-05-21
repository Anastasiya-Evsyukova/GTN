using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTNL.Models
{
    //результат одной попытки.
    public class GuessResult
    {
        public GuessOutcome Outcome { get; init; }
        public int AttemptsLeft { get; init; } //сколько попыток остальсь после ЭТОГО хода
        public bool IsGameFinished { get; init; }
        public int? SecretNumber { get; init; }

        //конструктор класса
        public GuessResult(GuessOutcome outcome, int attemptsLeft, bool isGameFinished, int? secretNumber = null) //secretNumber опционально, по умолчанию null
        {
            //инициализация
            Outcome = outcome;
            AttemptsLeft = attemptsLeft;
            IsGameFinished = isGameFinished;
            SecretNumber = secretNumber;
        }
    }
}