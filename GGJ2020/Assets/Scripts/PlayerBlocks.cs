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
        nearestMovableBlock.Push(nearestMovableBlock.position.GetDirection(playerCenter.position));
    }

    public bool CanMoveNearest()
    {
        return nearestMovableBlock &&
            currentLevel.CheckIsEmpty(
                nearestMovableBlock.position +
                nearestMovableBlock.position.GetDirection(playerCenter.position)) &&
            !currentLevel.CheckIsMovable(nearestMovableBlock.position + Vector3Int.up);
    }
}