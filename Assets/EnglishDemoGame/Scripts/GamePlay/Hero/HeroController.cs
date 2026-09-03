using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using EnglishDemoGame.Scripts.Platform.PC;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero
{
    public class HeroController : MonoBehaviour, IDamageable
    {

        private IHeroMover _heroMover;
        private InputReaderPC _inputReaderPC;
        private Vector2 _currentInput;

        public bool IsAlive => _currentHealth > 0;

        private float _maxHealth = 100f;
        private  float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }
        public void ApplyDamage(float damage)
        {
            if (!IsAlive)
                return;

            _currentHealth = Mathf.Max(0f, _currentHealth - damage);

            Debug.Log($"Player received damage: {damage}");

            if (!IsAlive)
            {
                Destroy(gameObject);
            }
        }

        [Inject]
        public void Construct(InputReaderPC inputReaderPC, IHeroMover heroMover)
        {
            _inputReaderPC = inputReaderPC;
            _heroMover = heroMover;

        }

        private void OnEnable()
        {
            _inputReaderPC.MoveEvent += OnInputChanged;
        }

        private void FixedUpdate()
        {
            _heroMover.Move(_currentInput);
        }

        private void OnDisable()
        {
            _inputReaderPC.MoveEvent -= OnInputChanged;
        }


        private void OnInputChanged(Vector2 value)
        {
           _currentInput = value;
        }

       
    }
}
