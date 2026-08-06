using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface
{
    public interface IEnemyState
    {
        EnemyStateType StateType { get; }
        void Enter();
        void Exit();
        void Update();
        bool CanTransitionTo(EnemyStateType nextState);

    }
}