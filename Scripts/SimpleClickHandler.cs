using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[AddComponentMenu("UI/SimpleClickHandler")]
public class SimpleClickHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onClick;
    public UnityEvent onDown;
    public UnityEvent onUp;

    public void OnPointerClick(PointerEventData eventData) => onClick.Invoke();
    public void OnPointerDown(PointerEventData eventData) => onDown.Invoke();
    public void OnPointerUp(PointerEventData eventData) => onUp.Invoke();
}
