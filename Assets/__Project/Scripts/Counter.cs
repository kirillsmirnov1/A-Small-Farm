using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    protected TextMeshProUGUI _text;
    protected int _counter;
    
    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        if (_text == null) Debug.LogWarning($"{gameObject.name}: no TMPro found in children");
    }

    public virtual void IncrementScore()
    {
        _counter++;
        _text.text = _counter.ToString();
    }
}
