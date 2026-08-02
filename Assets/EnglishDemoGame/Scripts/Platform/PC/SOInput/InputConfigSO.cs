using UnityEngine;
using UnityEngine.InputSystem;


namespace EnglishDemoGame.Scripts.Platform.PC.SOInput
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "Configs/Input Config")]
    public class InputConfigSO : ScriptableObject
    {
        [SerializeField] private InputActionAsset _inputActions;
        [SerializeField] private string _mapName = "Hero";
        [SerializeField] private string _moveActionName = "HeroMovement";

        public InputActionAsset InputActions => _inputActions;
        public string MapName => _mapName;
        public string MoveActionName => _moveActionName;
    }
}