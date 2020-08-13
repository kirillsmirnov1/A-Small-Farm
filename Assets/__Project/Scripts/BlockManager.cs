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
        // Handle holding mouse over empty space as cancelling the operation 
        bool objectOverAnyBlock = _blocks.Any(block => block.ObjectOverBlock);
        // Debug.Log($"Operation finished, anyMouseOver: {objectOverAnyBlock}");   
        foreach (var block in _blocks)
        {
            block.CompleteOperation(movableType, objectOverAnyBlock);
        }
    }
}
