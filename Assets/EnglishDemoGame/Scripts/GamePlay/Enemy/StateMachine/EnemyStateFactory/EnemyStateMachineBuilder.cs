using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider.Interface;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory
{
    public sealed class EnemyStateMachineBuilder
    {
        private readonly EnemyStateMachine _stateMachine;
        private readonly IEnemyStateFactory _stateFactory;
        private readonly IEnemyPositionProvider _enemyPosition;
        private readonly ITargetProvider _targetProvider;
        private readonly IEnemyAttackModel _attackModel;

        public EnemyStateMachineBuilder(
            EnemyStateMachine stateMachine,
            IEnemyStateFactory stateFactory,
            IEnemyPositionProvider enemyPosition,
            ITargetProvider targetProvider,
            IEnemyAttackModel attackModel)
        {
            _stateMachine = stateMachine;
            _stateFactory = stateFactory;
            _enemyPosition = enemyPosition;
            _targetProvider = targetProvider;
            _attackModel = attackModel;
        }

        public EnemyStateMachine Build()
        {
            var chaseState = _stateFactory.Create(EnemyStateType.Chase);
            var attackState = _stateFactory.Create(EnemyStateType.Attack);

            var targetInRange =
                new IsTargetInAttackRangePredicate(
                    _enemyPosition,
                    _targetProvider,
                    _attackModel);

            var targetOutOfRange =
               new IsTargetOutOfAttackRangePredicate(
                   _enemyPosition,
                   _targetProvider,
                   _attackModel);


            _stateMachine.AddTransition(
                chaseState,
                attackState,
                targetInRange);

            _stateMachine.AddTransition(
                attackState,
                chaseState,
                targetOutOfRange);

            _stateMachine.SetState(chaseState);

            return _stateMachine;
        }
    }
}