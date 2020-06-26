using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityKit {
    public abstract class UIScreenTransitionBehaviour : MonoBehaviour {
        public abstract void TransitionIn(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null);
        public abstract void TransitionOut(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null);
    }
}