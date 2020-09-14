using UnityEngine;
using UnityEngine.Events;

namespace UnityKit {
    public class ActionOnKeyPressed : MonoBehaviour {
        [SerializeField] private KeyCode keyCode;
        [SerializeField] private UnityEvent onKeyPressedEvent;
        

        private void Update() {
            if (!Input.GetKeyDown(keyCode)) return;
            
            onKeyPressedEvent.Invoke();
        }
    }
}