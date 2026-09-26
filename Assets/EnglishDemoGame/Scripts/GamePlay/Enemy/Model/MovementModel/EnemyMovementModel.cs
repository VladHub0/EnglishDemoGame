
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel
{
    public class EnemyMovementModel : IEnemyMovementModel
    {
        private readonly EnemyMovementSO _enemyMovementSO; 
        public EnemyMovementModel(EnemyMovementSO enemyMovementSO)
        {
            _enemyMovementSO = enemyMovementSO;
            Speed = enemyMovementSO.speed;
            StoppingDistance = enemyMovementSO.StoppingDistance;
        }
        public float Speed { get; private set; }

        public float StoppingDistance { get; private set; }

    }
}
