using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using UnityEngine;
using Zenject;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States
{
    public abstract class EnemyBasicState : IEnemyState
    {

        protected readonly IEnemyMovementService _enemyMovementService;

        [Inject]
        public EnemyBasicState(IEnemyMovementService enemyMovementService)
        {
            _enemyMovementService = enemyMovementService;
        }
        
        public virtual void Enter()
        {
            Debug.Log("The Enter Basic State");
        }


        public virtual void Update()
        {
            Debug.Log("The Update Basic State");
        }

        public virtual void Exit()
        {
            Debug.Log("The Exit Basic State");
        }

    }
}

