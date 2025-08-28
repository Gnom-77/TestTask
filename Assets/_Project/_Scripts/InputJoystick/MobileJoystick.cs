using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _handle;
    [SerializeField] private float _handleLimit = 100f;

    private Vector2 _inputVector;

    public Vector2 InputVector => _inputVector;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _background.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 pos);

        pos = Vector2.ClampMagnitude(pos, _handleLimit);
        _handle.rectTransform.anchoredPosition = pos;

        _inputVector = pos / _handleLimit;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        _handle.rectTransform.anchoredPosition = Vector2.zero;
    }
}
