using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class LocalMultiplayerSetup : MonoBehaviour {

    [SerializeField] private string keyboardControlScheme = "Keyboard";
    [SerializeField] private string keyboardLeftControlScheme = "KeyboardLeft";
    [SerializeField] private string keyboardRightControlScheme = "KeyboardRight";

    [SerializeField] private PlayerInput player1;
    [SerializeField] private PlayerInput player2;

    void Start() {
        BindPlayerInputs();
    }
    
    private void BindPlayerInputs() {
        // var player1 = PlayerInput.all[0];
        // var player2 = PlayerInput.all[1];
 
        // Discard existing assignments.
        player1.user.UnpairDevices();
        player2.user.UnpairDevices();
 
        // Assign devices and control schemes.
        var gamepadCount = Gamepad.all.Count;
        switch (gamepadCount) {
            case >= 2:
                InputUser.PerformPairingWithDevice(Gamepad.all[0], user: player1.user);
                InputUser.PerformPairingWithDevice(Gamepad.all[1], user: player2.user);
 
                player1.user.ActivateControlScheme("Gamepad");
                player2.user.ActivateControlScheme("Gamepad");
                break;
            case 1:
                InputUser.PerformPairingWithDevice(Gamepad.all[0], user: player1.user);
                InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);
 
                player1.user.ActivateControlScheme("Gamepad");
                player2.user.ActivateControlScheme("KeyboardLeftAndRight");
                break;
            default:
                InputUser.PerformPairingWithDevice(Keyboard.current, user: player1.user);
                InputUser.PerformPairingWithDevice(Keyboard.current, user: player2.user);
 
                player1.user.ActivateControlScheme("KeyboardLeft");
                player2.user.ActivateControlScheme("KeyboardRight");
                break;
        }
    }
}