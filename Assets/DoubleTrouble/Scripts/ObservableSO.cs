using EAUnity.Event;
using UnityEngine;

namespace DoubleTrouble.Scripts {
    [CreateAssetMenu(fileName = "ObservableSO", menuName = "Event/ObservableSO", order = 0)]
    public abstract class ObservableSO : ScriptableObject, IGameEventData {
        public GameEvent observableEvent;

        protected void Notify() {
            observableEvent.Raise(this);
        }
    }
}