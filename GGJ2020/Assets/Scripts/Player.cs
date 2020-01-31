using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

public enum PlayerStatus
{
    Walk,
    Grab,
    MovingBlock
}

public class Player : MonoBehaviour
{
    public BlockLevel currentLevel;

    public PlayerStatus playerStatus;

    public List<MovableBlock> movableBlocks = new List<MovableBlock>();

    public MovableBlock nearestMovableBlock;

    public void CheckMovableBlock(MovableBlock block)
    {
        if (block.position.y == Mathf.RoundToInt(transform.position.y))
        {
            if (movableBlocks.Contains(block))
            {
                //do nothing
            }
            else
            {
                movableBlocks.Add(block);
                UpdateMovableBlocks();
            }
        }
        else
        {
            RemoveMovableBlock(block);
        }
    }

    public void RemoveMovableBlock(MovableBlock block)
    {
        if (movableBlocks.Contains(block))
        {
            movableBlocks.Remove(block);
            UpdateMovableBlocks();
        }
    }

    public void UpdateMovableBlocks()
    {
        MovableBlock block = movableBlocks
            .OrderBy(x => (transform.position - x.transform.position).magnitude)
            .FirstOrDefault();

        nearestMovableBlock = block;
        Debug.Log($"the nearest movable block is {block}");
    }
}