using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTNL.Interfaces;
using GTNL.Models;

namespace GTNL.Services
{
    public class GameEngine : IGameEngine
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IUserInterface _userInterface;

        private int _secretNumber;
        private int _attemptsLeft;
        private IGameSettings? _currentSettings;

        public GameState State { get; private set; } = GameState.NotStarted;

        public GameEngine(INumberGenerator numberGenerator, IUserInterface userInterface)
        {
            _numberGenerator = numberGenerator;
            _userInterface = userInterface;
        }

        public void StartNewGame(IGameSettings settings)
        {
            _currentSettings = settings ?? throw new ArgumentNullException(nameof(settings));
            _secretNumber = _numberGenerator.Generate(settings.MinValue, settings.MaxValue);
            _attemptsLeft = settings.MaxAttempts;
            State = GameState.InProgress;
        }

        public GuessResult Guess(int number)
        {
            if (State != GameState.InProgress)
                return new GuessResult(GuessOutcome.Invalid, _attemptsLeft, true);

            _attemptsLeft--;

            if (number == _secretNumber)
            {
                State = GameState.Won;
                return new GuessResult(GuessOutcome.Equal, _attemptsLeft, true, _secretNumber);
            }

            if (_attemptsLeft == 0)
            {
                State = GameState.Lost;
                return new GuessResult(
                    number < _secretNumber ? GuessOutcome.Less : GuessOutcome.Greater,
                    0,
                    true,
                    _secretNumber);
            }

            var outcome = number < _secretNumber ? GuessOutcome.Less : GuessOutcome.Greater;
            return new GuessResult(outcome, _attemptsLeft, false);
        }
    }
}