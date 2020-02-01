using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MovableBlock : Block
    {
        public void UpdateGrabbed(Player player)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                player.PlayerMoveBlockForward();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                player.PlayerMoveBlockBack();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            other.GetComponent<Player>()?.CheckMovableBlock(this);
        }

        private void OnTriggerExit(Collider other)
        {
            other.GetComponent<Player>()?.RemoveMovableBlock(this);
        }
    }
}