using UnityEngine;

public class PickupItem : MonoBehaviour {
    [SerializeField] private Collider2D colliderRef;
    private bool _picked = false;
    
    public bool PickItem() {
        if (_picked) return false;
        //colliderRef.enabled = false;
        _picked = true;
        return true;
    }

    public void Init() {
        _picked = false;
    }

    public bool Picked => _picked;
}
