using UnityEngine;

namespace Tests {
    using UnityEngine;
    using UnityEngine.InputSystem;
    public class BasicRebinding : MonoBehaviour
    {
        public InputActionReference triggerAction;
        
        void ChangeBinding() {
            InputBinding binding = triggerAction.action.bindings[0];
            binding.overridePath = "<Keyboard>/#(f)";
            triggerAction.action.ApplyBindingOverride(0, binding);
        }
    }
}