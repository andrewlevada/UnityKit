using UnityEngine;
using DG.Tweening;

namespace UnityKit {
    public class FadeOnUIScreenTransitionBehaviour : UIScreenTransitionBehaviour {
        public float speed;

        public override void TransitionIn(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null) {
            CanvasGroup canvasGroupFrom = from.GetComponent<CanvasGroup>();
            canvasGroupFrom.DOFade(0f, speed).onComplete = () => from.gameObject.SetActive(false);

            to.gameObject.SetActive(true);
            CanvasGroup canvasGroupTo = to.GetComponent<CanvasGroup>();
            canvasGroupTo.alpha = 0f;
            canvasGroupTo.DOFade(1f, speed).onComplete = () => callback?.Invoke();
        }

        public override void TransitionOut(UIScreen from, UIScreen to, UIScreen.DoneCallback callback = null) {
            from.gameObject.SetActive(true);
            CanvasGroup canvasGroupFrom = from.GetComponent<CanvasGroup>();
            canvasGroupFrom.alpha = 0f;
            canvasGroupFrom.DOFade(1f, speed).onComplete = () => callback?.Invoke();

            CanvasGroup canvasGroupTo = to.GetComponent<CanvasGroup>();
            canvasGroupTo.DOFade(0f, speed).onComplete = () => to.gameObject.SetActive(false);
        }
    }
}