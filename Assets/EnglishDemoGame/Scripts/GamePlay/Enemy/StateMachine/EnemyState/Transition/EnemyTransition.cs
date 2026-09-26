
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Transition.Interface;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Transition
{
    public class EnemyTransition : ITransition
    {
        public IEnemyState To { get; }

        public IPredicate Condition { get; }


        public EnemyTransition(IEnemyState to, IPredicate condition)
        {
            To = to;
            Condition = condition;
        }
    }
}
