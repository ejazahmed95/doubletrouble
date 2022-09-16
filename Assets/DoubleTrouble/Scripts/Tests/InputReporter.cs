using EAUnity.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests {
    public class InputReporter : MonoBehaviour {
        
        void Update() {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            if(Keyboard.current.anyKey.wasPressedThisFrame)
            {
                Log.Debug($"A key was pressed ");
            }
            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                Log.Debug("A button was pressed");
            }
        }
    }
}