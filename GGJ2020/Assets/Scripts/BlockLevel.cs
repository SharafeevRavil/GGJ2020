using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DefaultNamespace;
using UnityEngine;

public class BlockLevel : MonoBehaviour
{
    [SerializeField] public LevelConfiguration LevelConfiguration;

    public Vector3Int LevelSize { get; private set; }

    public void Start()
    {
        LevelSize = LevelConfiguration.levelSize;
        _blocks = new Block[LevelSize.x, LevelSize.y, LevelSize.z];

        string textFileName = LevelConfiguration.levelConfigurationFile;
        string configText = ((TextAsset) Resources.Load($"Levels/{textFileName}")).text;
        string[][] lines = configText
            .Split('\n')
            .Select(x => x
                .Split()
                .Where(y => y.Length > 0)
                .ToArray()
            )
            .ToArray();
        //читаем y раз горизонтальные слайсы уровня
        for (int y = 0; y < LevelSize.y; y++)
        {
            //читаем z раз строчки (по х) в слайсе
            for (int z = 0; z < LevelSize.z; z++)
            {
                string[] line = lines[(LevelSize.z + 1) * y + z];
                for (int x = 0; x < LevelSize.x; x++)
                {
                    int id = int.Parse(line[x]);
                    List<GameObject> blockPrefabs = BlockManager.Instance.allBlocksPrefabs;
                    if (blockPrefabs.Count > id && blockPrefabs[id] != null)
                    {
                        Block curBlock = Instantiate(blockPrefabs[id], new Vector3(x, y, z), Quaternion.identity,
                            transform).GetComponent<Block>();
                        _blocks[x, y, z] = curBlock;
                        curBlock.position = new Vector3Int(x, y, z);
                        curBlock.blockLevel = this;
                        Debug.Log($"Block on {curBlock.position} has created. His id is {id}");
                    }
                    else
                    {
                        _blocks[x, y, z] = null;
                        Debug.Log($"Block on {new Vector3Int(x, y, z)} has not created. No configured id {id}");
                    }
                }
            }
        }
    }

    public void MoveBlock(Vector3Int from, Vector3Int to)
    {
        Block block = _blocks[from.x, from.y, from.z];
        block.position = to;
        _blocks[from.x, from.y, from.z] = null;
        _blocks[to.x, to.y, to.z] = block;

        if (block.position.y > 0 && !_blocks[block.position.x, block.position.y - 1, block.position.z])
        {
            ((MovableBlock)block).Push(Vector3Int.down);
        }
        else
        {
            CheckElectric();
        }
    }

    public bool CheckIsEmpty(Vector3Int position)
    {
        return position.x >= 0 && position.x < LevelSize.x &&
               position.y >= 0 && position.y < LevelSize.y &&
               position.z >= 0 && position.z < LevelSize.z &&
               !_blocks[position.x, position.y, position.z];
    }

    public Block[,,] _blocks;


    public void CheckElectric()
    {
        bool[,,] visited = new bool[LevelSize.x, LevelSize.y, LevelSize.z];
        ElectricGeneratorBlock generatorBlock = null;
        foreach (var block in _blocks)
        {
            if (block is ElectricGeneratorBlock)
            {
                generatorBlock = (ElectricGeneratorBlock) block;
            }
        }
        Recursion(visited, generatorBlock.position);
    }

    public void ReceiverHasEnabled()
    {
        Debug.Log("YOU WIN");
        testWin.SetActive(true);
        
    }

    public GameObject testWin;
    
    public void Recursion(bool[,,] visited, Vector3Int position)
    {
        if (position.x < 0 || position.x >= LevelSize.x ||
            position.y < 0 || position.y >= LevelSize.y ||
            position.z < 0 || position.z >= LevelSize.z ||
            visited[position.x, position.y, position.z] ||
            !(_blocks[position.x, position.y, position.z] is IElectricBlock) ||
            !((IElectricBlock) _blocks[position.x, position.y, position.z]).IsActivated)
        {
            return;
        }

        visited[position.x, position.y, position.z] = true;
        Recursion(visited, position + new Vector3Int(0, 0, -1));
        Recursion(visited, position + new Vector3Int(0, 0, 1));
        Recursion(visited, position + new Vector3Int(0, -1, 0));
        Recursion(visited, position + new Vector3Int(0, 1, 0));
        Recursion(visited, position + new Vector3Int(-1, 0, 0));
        Recursion(visited, position + new Vector3Int(1, 0, 0));
    }
}

[Serializable]
public class LevelConfiguration
{
    [SerializeField] public Vector3Int levelSize;

    [SerializeField] public string levelConfigurationFile;
}