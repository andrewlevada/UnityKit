using UnityEngine;

public class SelfDestroier : MonoBehaviour
{
    public void selfDestroy() => Destroy(gameObject);
}
