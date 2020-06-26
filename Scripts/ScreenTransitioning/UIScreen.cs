using UnityEngine;

namespace UnityKit {

    public class UIScreen : MonoBehaviour {
        public delegate void DoneCallback();
        
        public UIScreenTransitionBehaviour behaviour;

        public UIScreenTransition BackTransition { get; set; }
        
        public void MoveTo(UIScreen to, DoneCallback callback) {
            UIScreenTransition transition = new UIScreenTransition(this, to, behaviour, callback);
            to.BackTransition = transition;
            transition.Perform();
        }
        
        public void MoveTo(UIScreen to) {
            UIScreenTransition transition = new UIScreenTransition(this, to, behaviour);
            to.BackTransition = transition;
            transition.Perform();
        }
        
        public void MoveBack(DoneCallback callback) {
            if (BackTransition == null) return;
            BackTransition.Callback = callback;
            BackTransition.PerformBack();
            BackTransition = null;
        }
        
        public void MoveBack() {
            if (BackTransition == null) return;
            BackTransition.PerformBack();
            BackTransition = null;
        }
    }
}