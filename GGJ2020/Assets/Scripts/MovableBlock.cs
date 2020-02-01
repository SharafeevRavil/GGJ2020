using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class MovableBlock : Block
    {
        public float pushSpeed;

        private void OnTriggerStay(Collider other)
        {
            other.GetComponent<PlayerBlocks>()?.CheckMovableBlock(this);
        }

        private void OnTriggerExit(Collider other)
        {
            other.GetComponent<PlayerBlocks>()?.RemoveMovableBlock(this);
        }

        public void Push(Vector3Int direction)
        {
            _pushStart = position;
            _pushEnd = position + direction;
            StartCoroutine(MoveCoroutine());
        }

        private Vector3Int _pushStart;
        private Vector3Int _pushEnd;
        private float _pushT;

        public IEnumerator MoveCoroutine()
        {
            _pushT = 0;
            while ((transform.position - _pushEnd).magnitude > 0.01f)
            {
                _pushT += Time.deltaTime * pushSpeed / (_pushEnd - _pushStart).magnitude;
                transform.position = Vector3.Slerp(_pushStart, _pushEnd, _pushT);
                yield return null;
            }

            transform.position = _pushEnd;
            blockLevel.MoveBlock(_pushStart, _pushEnd);
        }
    }
}