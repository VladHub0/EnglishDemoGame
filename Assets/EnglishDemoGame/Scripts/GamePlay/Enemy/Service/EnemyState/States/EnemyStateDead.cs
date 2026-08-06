using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State
{

    public class EnemyStateDead : IEnemyState
    {
        public EnemyStateType StateType => throw new System.NotImplementedException();

        public bool CanTransitionTo(EnemyStateType nextState)
        {
            throw new System.NotImplementedException();
        }

        public void Construct()
        {
            throw new System.NotImplementedException();
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
