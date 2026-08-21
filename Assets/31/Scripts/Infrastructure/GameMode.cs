using System;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;

namespace _31.Scripts.Infrastructure
{
    public class GameMode: IDisposable
    {
        public event Action Win;
        public event Action Lose;
        
        private readonly IWinCondition _winCondition;
        private readonly ILoseCondition _loseCondition;

        public bool IsFinished { get; private set; }

        public GameMode(
            IWinCondition winCondition,
            ILoseCondition loseCondition)
        {
            _winCondition = winCondition;
            _loseCondition = loseCondition;
        }

        public void Update()
        {
            if (IsFinished)
                return;

            if (_loseCondition.IsCompleted)
            {
                IsFinished = true;
                Lose?.Invoke();
                return;
            }

            if (_winCondition.IsCompleted)
            {
                IsFinished = true;
                Win?.Invoke();
            }
        }

        public void Dispose()
        {
            if (_winCondition is IDisposable winConditionDisposable)
                winConditionDisposable.Dispose();
            
            if (_loseCondition is IDisposable loseConditionDisposable)
                loseConditionDisposable.Dispose();
        }
    }
}