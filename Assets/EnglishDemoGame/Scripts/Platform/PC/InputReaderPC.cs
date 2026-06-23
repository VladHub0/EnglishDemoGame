using UnityEngine;
using UnityEngine.InputSystem;

using EnglishDemoGame.Scripts.Core.Utils.InputUtils;
using System;

namespace EnglishDemoGame.Scripts.Platform.PC
{
    public class InputReaderPC : MonoBehaviour
    {
        [SerializeField] InputActionAsset _inputActions;


        private const string _mapName = "Hero";
        private const string _moveActionName = "HeroMovment";

        private InputActionMap _inputActionMap;
        private InputAction _moveAction;

        public event Action<Vector2> MoveEvent;
        private void Awake()
        {
            if (!InputActionUtils.TryGetInputActionMap(_inputActions, _mapName, out _inputActionMap))
            {
                return;
            }

            if(!InputActionUtils.TryGetAction(_inputActionMap, _moveActionName, out _moveAction))
            {
                return;
            }
        }

        private void OnEnable()
        {
            _inputActionMap.Enable();

            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCanceled;
            _moveAction.ReadValue<Vector2>();
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(Vector2.zero);
        }

        

        private void OnDisable()
        {
             _inputActionMap.Disable();

            _moveAction.performed -= OnMovePerformed;
            _moveAction.canceled -= OnMoveCanceled;
        }
    }
}
