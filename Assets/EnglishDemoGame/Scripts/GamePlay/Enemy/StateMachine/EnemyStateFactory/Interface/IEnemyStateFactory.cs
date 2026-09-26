using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface
{
    public interface IEnemyStateFactory : IFactory <EnemyStateType, IEnemyState>
    {
       
    }
}