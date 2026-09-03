
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter
{
    public class EnemyBasePresenter : IEnemyPresenter
    {
        private readonly EnemyStateMachineBuilder _enemyStateMachineBuilder;
        private  EnemyStateMachine _enemyStateMachine;

        [Inject]
        public EnemyBasePresenter(EnemyStateMachineBuilder enemyStateMachineBuilder)
        {
         
            _enemyStateMachineBuilder = enemyStateMachineBuilder;
            _enemyStateMachine = _enemyStateMachineBuilder.Build();
           
        }
        public void Tick()
        {
           
            _enemyStateMachine.Update();
        }
    }
}
