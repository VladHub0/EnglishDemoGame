using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider.Interface;
using Zenject;

using UnityEngine;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService
{
    public class EnemyMovementService : IEnemyMovementService
    {
        private readonly IEnemyMovementModel _enemyMovementModel;
        private readonly IEnemyView _enemyView;
        private readonly ITargetProvider _targetProvider;

        [Inject]
        public EnemyMovementService(ITargetProvider targetProvider, IEnemyMovementModel enemyMovementModel, IEnemyView enemyView)
        {
            _targetProvider = targetProvider;
            _enemyMovementModel = enemyMovementModel;
            _enemyView = enemyView;
        }

        public void MoveToTarget()
        {
            var currentPosition = _enemyView.Position;
            var targetPosition = _targetProvider.GetTargetPosition();

            var direction = (targetPosition - currentPosition).normalized;
            var distance = Vector3.Distance(currentPosition, targetPosition);

            if (distance <= _enemyMovementModel.StoppingDistance)
            {
                return;
            }

            var step = _enemyMovementModel.Speed * Time.deltaTime;
            var newPosition = Vector3.MoveTowards(
                currentPosition,
                targetPosition,
                step);

            _enemyView.SetPosition(newPosition);
            _enemyView.SetDirection(direction);
        }
    }
}