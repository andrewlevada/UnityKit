namespace UnityKit.ScreenTransitioning {
    public class UIScreenTransition {
        private readonly UIScreen from;
        private readonly UIScreen to;
        private readonly UIScreenTransitionBehaviour behaviour;

        public UIScreenTransition(UIScreen from, UIScreen to, UIScreenTransitionBehaviour behaviour,
            UIScreen.DoneCallback callback = null) {
            this.from = from;
            this.to = to;
            this.behaviour = behaviour;
            this.callback = callback;
        }

        public UIScreen.DoneCallback callback { get; set; }

        public void Perform() {
            if (callback != null) behaviour.TransitionIn(from, to, callback);
            else behaviour.TransitionIn(from, to);
            callback = null;
        }

        public void PerformBack() {
            if (callback != null) behaviour.TransitionOut(from, to, callback);
            else behaviour.TransitionOut(from, to);
            callback = null;
        }
    }
}