using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MovesWithMouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Movable typeOfMovable;
    
    private RectTransform _rectTransform;
    private Vector3 _idlePosition;
    private bool _underPlayerControl;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _idlePosition = _rectTransform.localPosition;
    }

    private void Update()
    {
        if (_underPlayerControl)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _underPlayerControl = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BlockManager.FinishOperation(typeOfMovable);
        _underPlayerControl = false;
        _rectTransform.localPosition = _idlePosition;
    }
    
    public enum Movable { Ground, Wheat, Sickle }
}
