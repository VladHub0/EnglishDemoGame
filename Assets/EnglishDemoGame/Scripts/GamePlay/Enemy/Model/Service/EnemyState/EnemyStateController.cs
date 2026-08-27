using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy.Interface;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState
{
    public class EnemyStateController
    {
        private IEnemyState _currentState;
        private readonly Dictionary<EnemyStateType, IEnemyState> _states = new();
        private EnemyStateType _previousState;
        private IEnemyStateFactory _factory;
        private DiContainer _container;


        

        public EnemyStateType PreviousState => _previousState;

        [Inject]
        public void Construct(IEnemyStateFactory factory, DiContainer container)
        {
            _factory = factory;
            _container = container;
        }

        private void Start()
        {
            _currentState = _factory.CreateState(EnemyStateType.Start);
            _previousState = EnemyStateType.Start;
            _container.Inject(_currentState);
            _currentState.Enter();

           
        }

        private void Update()
        {
            _currentState?.Update();
        }

        public void SetState(EnemyStateType newStateType)
        {
            if (_currentState == null || !_currentState.CanTransitionTo(newStateType))
                return;

            _currentState.Exit();

            if (!_states.TryGetValue(newStateType, out var newState))
            {
                newState = _factory.CreateState(newStateType);
                _container.Inject(newState);
                _states[newStateType] = newState;
            }

            _previousState = _currentState.StateType;
            _currentState = newState;
            _currentState.Enter();
        }
    }
}