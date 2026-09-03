using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider.Interface;
using UnityEngine;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate
{
    public sealed class IsTargetInAttackRangePredicate : IPredicate
    {
        private readonly IEnemyPositionProvider _enemyPosition;
        private readonly ITargetProvider _targetProvider;
        private readonly IEnemyAttackModel _attackModel;

        public IsTargetInAttackRangePredicate(
            IEnemyPositionProvider enemyPosition,
            ITargetProvider targetProvider,
            IEnemyAttackModel attackModel)
        {
            _enemyPosition = enemyPosition;
            _targetProvider = targetProvider;
            _attackModel = attackModel;
        }

        public bool Evaluate()
        {
            var targetPosition = _targetProvider.GetTargetPosition();

            var distance = Vector3.Distance(
                _enemyPosition.Position,
                targetPosition);

            return distance <= _attackModel.AttackRange;
        }
    }
}