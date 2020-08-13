using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private Block[] _blocks;
    private static BlockManager _instance;
    
    private void Awake()
    {
        _instance = this;
        _blocks = GetComponentsInChildren<Block>();
    }

    public static void FinishOperation(MovesWithMouse.Movable movableType)
    {
        _instance.ActuallyFinishOperation(movableType);
    }

    private void ActuallyFinishOperation(MovesWithMouse.Movable movableType)
    {
        bool anyMouseOver = _blocks.Any(block => block.ObjectOverBlock);
        Debug.Log($"Operation finished, anyMouseOver: {anyMouseOver}");   
        foreach (var block in _blocks)
        {
            block.CompleteOperation(movableType, anyMouseOver);
        }
    }
}
