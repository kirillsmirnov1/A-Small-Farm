public class GroundCounter : Counter
{
    public int maxNumberOfGround = 16;
    
    public override void IncrementScore()
    {
        _counter++;
        _text.text = $"{_counter} / {maxNumberOfGround}";
    }
}
