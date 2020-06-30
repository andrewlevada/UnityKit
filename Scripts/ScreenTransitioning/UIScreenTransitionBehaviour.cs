using UnityEngine;

namespace UnityKit.ScreenTransitioning {
    public abstract class UIScreenTransitionBehaviour : MonoBehaviour {
        public abstract void TransitionIn(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null);
        public abstract void TransitionOut(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null);
    }
}