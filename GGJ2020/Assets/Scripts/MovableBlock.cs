using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MovableBlock : Block
    {
        public void UpdateGrabbed(PlayerBlocks playerBlocks)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerBlocks.PlayerMoveBlockForward();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                playerBlocks.PlayerMoveBlockBack();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            other.GetComponent<PlayerBlocks>()?.CheckMovableBlock(this);
        }

        private void OnTriggerExit(Collider other)
        {
            other.GetComponent<PlayerBlocks>()?.RemoveMovableBlock(this);
        }
    }
}