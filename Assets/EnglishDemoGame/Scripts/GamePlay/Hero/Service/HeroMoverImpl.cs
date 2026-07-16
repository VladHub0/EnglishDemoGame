using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero.Service
{
    public class HeroMoverImpl : IHeroMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _moveSpeed;
        private readonly float _offset;

        [Inject]
        public HeroMoverImpl(Rigidbody2D rigidbody,[Inject(Id = "MoveSpeed")] float moveSpeed, [Inject(Id = "Offset")] float offset)
        {
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
            _offset = offset;
        }

        public void Move(Vector2 input)
        {
            Vector2 movement = input.normalized * _moveSpeed * Time.fixedDeltaTime;

            if (movement == Vector2.zero)
                return;

            Vector2 position = _rigidbody.position;

            if (TryMove(movement, out Vector2 possibleMovement))
            {
                _rigidbody.MovePosition(position + possibleMovement);
                return;
            }

            Vector2 horizontal = new Vector2(movement.x, 0f);
            Vector2 vertical = new Vector2(0f, movement.y);

            bool moved = false;

            if (horizontal != Vector2.zero && TryMove(horizontal, out Vector2 safeHorizontal))
            {
                position += safeHorizontal;
                _rigidbody.position = position;
                moved = true;
            }

            if (vertical != Vector2.zero && TryMove(vertical, out Vector2 safeVertical))
            {
                position += safeVertical;
                moved = true;
            }

            if (moved)
            {
                _rigidbody.MovePosition(position);
            }
        }

        private bool TryMove(Vector2 movement, out Vector2 possibleMovement)
        {
            possibleMovement = movement;

            float distance = movement.magnitude;
            if (distance <= 0f)
            {
                return false;
            }

            Vector2 direction = movement / distance;
            RaycastHit2D[] hits = new RaycastHit2D[5];

            int hitCount = _rigidbody.Cast(direction, hits, distance);

            if (hitCount == 0)
            {
                return true;
            }

            float safeDistance = hits[0].distance - _offset;

            if (safeDistance <= 0f)
            {
                possibleMovement = Vector2.zero;
                return false;
            }

            possibleMovement = direction * safeDistance;
            return true;
        }
    }
}