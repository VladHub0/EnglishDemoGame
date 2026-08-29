using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using UnityEngine;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States
{
    public class EnemyBasicState : IEnemyState
    {
        
        public void Enter()
        {
            Debug.Log("The Enter Basic State");
        }

        public void Exit()
        {
            Debug.Log("The Exit Basic State");
        }

        public void Update()
        {
            Debug.Log("The Update Basic State");
        }

    }
}

