
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate.Interface;
using System;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> _func;

        [Inject]
        public FuncPredicate(Func<bool> func)
        {
            _func = func;
        }
        public bool Evaluate()
        {
            return _func.Invoke();
        }
    }
}
