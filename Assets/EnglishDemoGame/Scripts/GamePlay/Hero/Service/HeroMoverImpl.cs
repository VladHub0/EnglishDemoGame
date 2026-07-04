using UnityEngine;

using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero.Service
{


    public class HeroMoverImpl : IHeroMover
    {

        private readonly Rigidbody2D _rigidbody;
        private readonly float _moveSpeed;

        [Inject]
        public HeroMoverImpl(Rigidbody2D rigidbody, float moveSpeed)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
        }
        public void Move(Vector2 input)
        {
            Vector2 newPos = _rigidbody.position + input * _moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPos);
        }
    }
}
