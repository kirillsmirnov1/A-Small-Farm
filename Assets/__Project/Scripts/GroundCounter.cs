public class GroundCounter : Counter
{
    public int maxNumberOfGroundObjects = 16;
    
    public override void IncrementScore()
    {
        _counter++;
        _text.text = $"{_counter} / {maxNumberOfGroundObjects}";
    }
}
