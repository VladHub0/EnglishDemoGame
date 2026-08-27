
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter
{
    public class EnemyBasePresenter : IEnemyPresenter
    {
        private readonly IEnemyMovementService _enemyMovementService;

        [Inject]
        public EnemyBasePresenter(IEnemyMovementService enemyMovementService)
        {
            _enemyMovementService = enemyMovementService;
        }
        public void Tick()
        {
            _enemyMovementService.MoveToTarget();
        }
    }
}
