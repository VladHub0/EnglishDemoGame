using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyStateFactory.Interface
{
    public interface IEnemyStateFactory : IFactory <IEnemyState>
    {
       
    }
}