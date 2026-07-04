using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using EnglishDemoGame.Scripts.Platform.PC;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero
{
    public class HeroController : MonoBehaviour
    {

        private IHeroMover _heroMover;
        private InputReaderPC _inputReaderPC;
        private Vector2 _currentInput;
        

        [Inject]
        public void Construct(InputReaderPC inputReaderPC, IHeroMover heroMover)
        {
            _inputReaderPC = inputReaderPC;
            _heroMover = heroMover;

            Debug.LogWarning("InputReaderPC injects dependency");
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
