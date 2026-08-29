using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using System.Collections.Generic;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState
{
    public class EnemyStateMachine
    {

        private readonly IEnemyStateFactory _enemyStateFactory;

        private Dictionary<EnemyStateType, IEnemyState> _states;

        private IEnemyState _currentState;

        [Inject]
        public EnemyStateMachine(IEnemyStateFactory enemyStateFactory)
        {
            _enemyStateFactory = enemyStateFactory;
            _states = new Dictionary<EnemyStateType, IEnemyState>();
        }
        public void InitStateMachine(EnemyStateType startStateType = EnemyStateType.Basic)
        {
            AddState(startStateType);
            SetState(startStateType);
        }

        public void AddState(EnemyStateType stateType)
        {
            if (_states.ContainsKey(stateType))
            {
                return;
            }

            var state = _enemyStateFactory.Create(stateType);
            _states[stateType] = state;
        }

        public void SetState(EnemyStateType stateType)
        {
            if (!_states.ContainsKey(stateType))
            {
                AddState(stateType);
            }

            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = _states[stateType];
            _currentState.Enter();
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Update();
            }
        }
    }
}