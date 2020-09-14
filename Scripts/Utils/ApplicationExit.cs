using UnityEngine;

namespace UnityKit {
    public class ApplicationExit : MonoBehaviour {
        [SerializeField] private bool doOnEsc;

        public void Exit() => Application.Quit();

        private void Update() {
            if (doOnEsc && Input.GetKey(KeyCode.Escape)) Exit();
        }
    }
}