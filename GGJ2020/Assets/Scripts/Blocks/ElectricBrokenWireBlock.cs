﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElectricBrokenWireBlock : Block, IElectricBlock
{
    public bool CheckRecursionActivated
    {
        get
        {
            var blocks = blockLevel._blocks;
            var levelSize = blockLevel.LevelSize;
            List<Vector3Int> neighbours = new List<Vector3Int>()
            {
                new Vector3Int(0, 0, -1),
                new Vector3Int(0, 0, 1),
                new Vector3Int(0, -1, 0),
                new Vector3Int(0, 1, 0),
                new Vector3Int(-1, 0, 0),
                new Vector3Int(1, 0, 0)
            };
            _enabled = neighbours.Select(x => x + position).Any(pos =>
                pos.x >= 0 && pos.x < levelSize.x &&
                pos.y >= 0 && pos.y < levelSize.y &&
                pos.z >= 0 && pos.z < levelSize.z &&
                blocks[pos.x, pos.y, pos.z] is ElectricMovableBlock);
            return _enabled;
        }
    }
    

    private bool _enabled = false;
    public void EnsureDisabled(bool visited)
    {
        if (!visited || !_enabled)
        {
            GetComponent<BlockMaterialChanger>().ChangeMaterial(false);
        }
        else
        {
            GetComponent<BlockMaterialChanger>().ChangeMaterial(true);
        }
    }
}