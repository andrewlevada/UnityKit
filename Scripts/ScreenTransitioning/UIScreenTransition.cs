using System.Collections;

namespace UnityKit {
    public class UIScreenTransition
    {
        private UIScreenTransitionBehaviour behaviour;
        
        public UIScreen.DoneCallback Callback { get; set; }

        private readonly UIScreen from;
        private readonly UIScreen to;

        public void Perform() {
            if (Callback != null) behaviour.TransitionIn(from, to, Callback);
            else behaviour.TransitionIn(from, to);
            Callback = null;
        }

        public void PerformBack() {
            if (Callback != null) behaviour.TransitionOut(from, to, Callback);
            else behaviour.TransitionOut(from, to);
            Callback = null;
        }

        public UIScreenTransition(UIScreen from, UIScreen to, UIScreenTransitionBehaviour behaviour, UIScreen.DoneCallback callback = null) {
            this.from = from;
            this.to = to;
            this.behaviour = behaviour;
            this.Callback = callback;
        }
    }
}