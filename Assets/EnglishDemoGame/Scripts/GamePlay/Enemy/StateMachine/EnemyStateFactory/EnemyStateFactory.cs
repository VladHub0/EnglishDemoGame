using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface;
using System;
using System.Collections.Generic;
using Zenject;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyFactory
{
    public class EnemyStateFactory : PlaceholderFactory<EnemyStateType, IEnemyState>, IEnemyStateFactory, IValidatable
    {
        private readonly IInstantiator _container;
        private readonly Dictionary<EnemyStateType, Type> _stateTypes;

        [Inject]
        public EnemyStateFactory(IInstantiator container)
        {
            _container = container;
            _stateTypes = new Dictionary<EnemyStateType, Type>
{
    { EnemyStateType.Chase, typeof(EnemyChaseState) },
    { EnemyStateType.Attack, typeof(EnemyAttackState) }
};
        }

        public override IEnemyState Create(EnemyStateType stateType)
        {
            if (!_stateTypes.ContainsKey(stateType))
            {
                throw new KeyNotFoundException($"State type {stateType} not found for EnemyState Machine");
            }

            var type = _stateTypes[stateType];
            return (IEnemyState)_container.Instantiate(type);
        }

        public override void Validate()
        {
           
        }
    }
}