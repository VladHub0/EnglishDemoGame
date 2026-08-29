
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter
{
    public class EnemyBasePresenter : IEnemyPresenter
    {
        private readonly IEnemyMovementService _enemyMovementService;
        private readonly EnemyStateMachine _enemyStateMachine;
        [Inject]
        public EnemyBasePresenter(IEnemyMovementService enemyMovementService, EnemyStateMachine enemyStateMachine)
        {
            _enemyMovementService = enemyMovementService;
            _enemyStateMachine = enemyStateMachine;
            _enemyStateMachine.InitStateMachine();
        }
        public void Tick()
        {
            _enemyMovementService.MoveToTarget();
            _enemyStateMachine.Update();
        }
    }
}
