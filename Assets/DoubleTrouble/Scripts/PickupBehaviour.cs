using EAUnity.Core;
using UnityEngine;
using UnityEngine.Events;

public class PickupBehaviour: MonoBehaviour {
    [SerializeField] private string pickItemTag = "Pickup";
    [SerializeField] private UnityEvent<PickupItem> onItemPicked = new();
    
    private void OnTriggerEnter2D(Collider2D col) {
        // Log.Debug("Trigger entered");
        if (col.CompareTag(pickItemTag) == false) return;
        var item = col.gameObject.GetComponent<PickupItem>();
        if (item == null || item.Picked) return;

        // Log.Debug("Picking Item");
        if (item.PickItem()) {
            onItemPicked.Invoke(item);
        };
    }
}