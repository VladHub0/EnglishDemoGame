

using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Transition.Interface
{
    public interface ITransition
    {
        IEnemyState To { get; }
        IPredicate Condition { get; }
    }
}
