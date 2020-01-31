using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MovableBlock : Block
    {
        public virtual void Move(Vector3Int direction){
            
        }
        

        public virtual void BeforeMove(Vector3 move)
        {
        
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