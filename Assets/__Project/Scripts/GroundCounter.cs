using UnityEngine;

public class GroundCounter : Counter
{
    [SerializeField]
    private int maxNumberOfGroundObjects = 16;
    
    public override void IncrementScore()
    {
        _counter++;
        _text.text = $"{_counter} / {maxNumberOfGroundObjects}";
    }
}
