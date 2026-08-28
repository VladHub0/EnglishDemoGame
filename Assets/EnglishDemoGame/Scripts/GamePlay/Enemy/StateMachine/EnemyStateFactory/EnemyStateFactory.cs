

using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyStateFactory.Interface;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy
{
    public class EnemyStateFactory : PlaceholderFactory<IEnemyState>, IEnemyStateFactory
    {
        public override IEnemyState Create()
        {
            return null;
        }

        public override void Validate()
        {
          
        }
    }
}