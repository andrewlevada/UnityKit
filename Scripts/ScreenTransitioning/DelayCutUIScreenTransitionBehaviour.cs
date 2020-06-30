using System.Collections;
using UnityEngine;

namespace UnityKit.ScreenTransitioning {
    public class DelayCutUIScreenTransitionBehaviour : UIScreenTransitionBehaviour {
        public float delay;

        public override void TransitionIn(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null) {
            StartCoroutine(WaitCoroutine(from, to, true, callback));
        }

        public override void TransitionOut(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null) {
            StartCoroutine(WaitCoroutine(from, to, false, callback));
        }

        private IEnumerator WaitCoroutine(UIScreen from, UIScreen to, bool isIn, UIScreen.DoneCallback callback) {
            yield return new WaitForSeconds(delay);
            
            from.gameObject.SetActive(!isIn);
            to.gameObject.SetActive(isIn);
            callback?.Invoke();
        }
    }
}
