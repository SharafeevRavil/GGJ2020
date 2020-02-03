using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [Tooltip(@"0 - ничего")] public List<GameObject> allBlocksPrefabs;
    public static BlockManager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
