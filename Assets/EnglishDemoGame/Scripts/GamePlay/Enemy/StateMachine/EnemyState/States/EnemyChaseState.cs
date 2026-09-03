using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States
{
    public class EnemyChaseState : EnemyBasicState
    {
        public EnemyChaseState(IEnemyMovementService enemyMovementService) : base(enemyMovementService)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            _enemyMovementService.MoveToTarget();
        }
    }
}
