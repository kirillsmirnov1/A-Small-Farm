using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Counter groundCounter;
    public Counter wheatCounter;

    public static Vector2 WheatCounterPosition;
    
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
        WheatCounterPosition = GameObject.FindWithTag("WheatCounter").GetComponent<RectTransform>().anchoredPosition;

        if(groundCounter == null) Debug.LogWarning($"{gameObject.name}: no groundCounter");
        if(wheatCounter == null) Debug.LogWarning($"{gameObject.name}: no wheatCounter");
    }

    public static void IncrementGroundCounter() => _instance.groundCounter.IncrementScore();
    public static void IncrementWheatCounter() => _instance.wheatCounter.IncrementScore();
}
