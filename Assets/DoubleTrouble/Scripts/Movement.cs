using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DoubleTrouble.Scripts {
	public class Movement : MonoBehaviour {
		[SerializeField] private Rigidbody2D _body;

		[SerializeField] private InputActionAsset controls;
		private InputActionMap _inputActionMap;

		private InputAction _moveAction;

		private void Start() {
			// _inputActionMap = controls.FindActionMap("Player");
			// _moveAction = _inputActionMap.FindAction("Move");
			// _moveAction.performed += OnMove;
		}

		private void OnMove(InputAction.CallbackContext ctx) {
			ctx.ReadValue<Vector2>();
		}
	}
}