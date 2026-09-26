using UnityEngine;

namespace EnglishDemoGame.Scripts.GamePlay.CommonInterface
{
    public abstract class Timer
    {
        private float _remainingTime;

        public bool IsCompleted => _remainingTime <= 0f;
        public float RemainingTime => _remainingTime;

        protected Timer(float duration)
        {
            if (duration < 0f)
                throw new System.ArgumentOutOfRangeException(
                    nameof(duration));

            _remainingTime = 0f;
            Duration = duration;
        }

        protected float Duration { get; }

        public void Start()
        {
            _remainingTime = Duration;
        }

        public void Reset()
        {
            _remainingTime = 0f;
        }

        public void Tick(float deltaTime)
        {
            if (deltaTime < 0f)
                return;

            if (IsCompleted)
                return;

            _remainingTime = Mathf.Max(
                0f,
                _remainingTime - deltaTime);
        }
    }
}