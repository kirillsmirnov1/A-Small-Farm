﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Counter groundCounter;
    [SerializeField]
    private Counter wheatCounter;

    public static Vector2 WheatCounterRectAnchoredPosition;
    
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
        WheatCounterRectAnchoredPosition = GameObject.FindWithTag("WheatCounter").GetComponent<RectTransform>().anchoredPosition;

        if(groundCounter == null) Debug.LogWarning($"{gameObject.name}: no groundCounter");
        if(wheatCounter == null) Debug.LogWarning($"{gameObject.name}: no wheatCounter");
    }

    public static void IncrementGroundCounter() => _instance.groundCounter.IncrementScore();
    public static void IncrementWheatCounter() => _instance.wheatCounter.IncrementScore();
}
