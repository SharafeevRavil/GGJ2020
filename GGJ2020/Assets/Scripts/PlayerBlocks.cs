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
    BlockMove
}

public class PlayerBlocks : MonoBehaviour
{
    public Transform playerCenter;

    public BlockLevel currentLevel;

    public List<MovableBlock> movableBlocks = new List<MovableBlock>();

    public MovableBlock nearestMovableBlock;

    public MovableBlock grabbedBlock;

    public void CheckMovableBlock(MovableBlock block)
    {
        if (block.position.y == Mathf.RoundToInt(playerCenter.position.y))
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

    public void PushNearestBlock()
    {
        Vector3Int blockPos = nearestMovableBlock.position;
        Vector3 diff = blockPos - playerCenter.position;
        Vector3Int direction;
        if (Math.Abs(diff.x) > Math.Abs(diff.z))
        {
            direction = diff.x > 0 ? Vector3Int.right : Vector3Int.left;
        }
        else
        {
            direction = diff.z > 0 ? new Vector3Int(0, 0, 1) : new Vector3Int(0, 0, -1);
        }

        nearestMovableBlock.Push(direction);
    }
}