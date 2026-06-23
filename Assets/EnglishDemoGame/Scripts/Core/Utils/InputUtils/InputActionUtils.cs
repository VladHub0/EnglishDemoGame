
using UnityEngine;
using UnityEngine.InputSystem;

namespace EnglishDemoGame.Scripts.Core.Utils.InputUtils
{
    public static class InputActionUtils
    {
        public static bool TryGetInputActionMap(InputActionAsset asset, string mapName, out InputActionMap map)
        {
            map = null;

            if (asset == null)
            {
                Debug.LogError("InputActionAsset is not assigned!");
                return false;
            }

            map = asset.FindActionMap(mapName);

            if (map == null)
            {
                Debug.LogError("InputActionMap  not found! " + mapName);
                return false;
            }

            return true;
        }

        public static bool TryGetAction(InputActionMap map, string actionName, out InputAction action)
        {
            action = null;
            if (map == null)
            {
                Debug.LogError($"Cannot find action '{actionName}' – map is null.");
                return false;
            }

            action = map.FindAction(actionName);
            if (action == null)
            {
                Debug.LogError($"Action '{actionName}' not found in map '{map.name}'.");
                return false;
            }
            return true;
        }
       
    }
}
