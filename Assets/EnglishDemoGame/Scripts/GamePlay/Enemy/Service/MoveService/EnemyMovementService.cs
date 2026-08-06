using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Hero;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService
{
    public class EnemyMovementService : IEnemyMovementService
    {
        private readonly Transform _transform;
        private readonly HeroController _hero;
        private readonly float _stoppingDistance = 0.5f;

        [Inject]
        public EnemyMovementService(Transform transform, HeroController hero)
        {
            _transform = transform;
            _hero = hero;
        }

        public void MoveToHero(float speed)
        {
            if (_hero == null) return;


            var heroPosition = _hero.transform.position;
            var direction = (heroPosition - _transform.position).normalized;

            var distance = Vector3.Distance(_transform.position, heroPosition);
            if (distance > _stoppingDistance)
            {
                var step = speed * Time.deltaTime;
                var newPosition = Vector3.MoveTowards(_transform.position, heroPosition, step);
                _transform.position = newPosition;
            }

        }


    }
}