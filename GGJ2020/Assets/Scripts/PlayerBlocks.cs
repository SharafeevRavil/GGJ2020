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
    public BlockLevel currentLevel;

    public PlayerStatus playerStatus;

    public List<MovableBlock> movableBlocks = new List<MovableBlock>();

    public MovableBlock nearestMovableBlock;

    public MovableBlock grabbedBlock;

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

    public void Update()
    {
        switch (playerStatus)
        {
            case PlayerStatus.Walk:
                if (nearestMovableBlock)
                {
                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        //todo grab
                        grabbedBlock = nearestMovableBlock;
                        playerStatus = PlayerStatus.Grab;
                    }
                }
                break;
            case PlayerStatus.Grab:
                if (Input.GetKeyDown(KeyCode.G))
                {
                    //todo release grab
                    grabbedBlock = null;
                    playerStatus = PlayerStatus.Walk;
                }
                else
                {
                    grabbedBlock.UpdateGrabbed(this);
                }
                break;
            case PlayerStatus.BlockMove:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void PlayerMoveBlockForward()
    {
        //anim
    }

    public void PlayerMoveBlockBack()
    {
        //anim
    }
}