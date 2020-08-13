using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MovesWithMouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Movable type;
    
    private RectTransform _rectTransform;
    private Vector3 _position;
    private bool _gotcha;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _position = _rectTransform.localPosition;
    }

    private void Update()
    {
        if (_gotcha)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _gotcha = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BlockManager.FinishOperation(type);
        _gotcha = false;
        _rectTransform.localPosition = _position;
    }
    
    public enum Movable { Ground, Wheat, Sickle }
}
