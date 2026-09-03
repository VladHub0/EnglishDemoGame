using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States
{
    public class EnemyAttackState : EnemyBasicState
    {

        private readonly IEnemyAttackService _enemyAttackService;
        private readonly IDamageable _target;
        private readonly Timer _timer;
        public EnemyAttackState(IEnemyMovementService enemyMovementService, 
            IEnemyAttackService enemyAttackService,
            Timer timer,
            IDamageable target) : base(enemyMovementService)
        {
            _enemyAttackService = enemyAttackService;
            _target = target;
            _timer = timer;
        }

        public override void Enter()
        {
            _timer.Reset();


            _enemyAttackService.Attack(_target);

            _timer.Start();
        }

        public override void Update()
        {
            _timer.Tick(Time.deltaTime);

            if (!_timer.IsCompleted)
                return;

            _enemyAttackService.Attack(_target);
            _timer.Start();
        }

        public override void Exit()
        {

        }
    }
}