using EnglishDemoGame.Scripts.Platform.PC;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5.0f;

        private InputReaderPC _inputReaderPC;
        private Vector2 _currentInput; 

        [Inject]
        public void Construct(InputReaderPC inputReaderPC)
        {
            _inputReaderPC = inputReaderPC;

            Debug.LogWarning("InputReaderPC injects dependency");
        }

        private void OnEnable()
        {
            _inputReaderPC.MoveEvent += OnInputChanged;
        }
        private void Update()
        {
            Vector3 movement = new Vector2(_currentInput.x, _currentInput.y);
            transform.position += movement * (moveSpeed * Time.deltaTime);
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
