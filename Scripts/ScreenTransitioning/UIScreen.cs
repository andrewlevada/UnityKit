using UnityEngine;

namespace UnityKit.ScreenTransitioning {
    /// <summary>
    /// <para>Used for easy transitions between screens on canvas</para>
    /// </summary>
    public class UIScreen : MonoBehaviour {
        public delegate void DoneCallback();

        public UIScreenTransitionBehaviour behaviour;

        private UIScreenTransition backTransition { get; set; }

        public void MoveTo(UIScreen to, DoneCallback callback) {
            if (!gameObject.activeInHierarchy) return;
            
            UIScreenTransition transition = new UIScreenTransition(this, to, behaviour, callback);
            to.backTransition = transition;
            transition.Perform();
        }

        public void MoveTo(UIScreen to) {
            if (!gameObject.activeInHierarchy) return;
            
            UIScreenTransition transition = new UIScreenTransition(this, to, behaviour);
            to.backTransition = transition;
            transition.Perform();
        }

        public void MoveBack(DoneCallback callback) {
            if (backTransition == null) return;
            
            backTransition.callback = callback;
            backTransition.PerformBack();
            backTransition = null;
        }

        public void MoveBack() {
            if (backTransition == null) return;
            
            backTransition.PerformBack();
            backTransition = null;
        }
    }
}