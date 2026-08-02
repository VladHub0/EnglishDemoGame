using UnityEngine;
using UnityEngine.InputSystem;

using EnglishDemoGame.Scripts.Core.Utils.InputUtils;
using System;
using Zenject;
using EnglishDemoGame.Scripts.Platform.PC.SOInput;

namespace EnglishDemoGame.Scripts.Platform.PC
{
    public class InputReaderPC : IInitializable, IDisposable
    {
        private readonly InputConfigSO _inputConfigSO;

        private InputActionMap _inputActionMap;
        private InputAction _moveAction;

        public event Action<Vector2> MoveEvent;

        [Inject]
        public InputReaderPC(InputConfigSO inputConfigSO)
        {
            _inputConfigSO = inputConfigSO;
        }

        public void Initialize()
        {
            if (!InputActionUtils.TryGetInputActionMap(_inputConfigSO.InputActions, _inputConfigSO.MapName, out _inputActionMap))
            {
                return;
            }

            if (!InputActionUtils.TryGetAction(_inputActionMap,_inputConfigSO.MoveActionName, out _moveAction))
            {
                return;
            }


            _inputActionMap.Enable();

            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCanceled;

        }

        public void Dispose()
        {
            _inputActionMap?.Disable();

            if (_moveAction != null)
            {
                _moveAction.performed -= OnMovePerformed;
                _moveAction.canceled -= OnMoveCanceled;
            }

            
        }


        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(Vector2.zero);
        }

    }
}
