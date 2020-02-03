using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3Int position;
    public BlockLevel blockLevel;

    public virtual void OnCreate()
    {
    }
}