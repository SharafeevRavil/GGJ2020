using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public List<LevelConfiguration> levels;

    public GameObject levelPrefab;

    public void Start()
    {
        CreateLevel(0);
    }

    public void CreateLevel(int id)
    {
        GameObject go = Instantiate(levelPrefab);
        BlockLevel level = go.GetComponent<BlockLevel>();

        level.InitLevel(this, levels[id], id);
    }

    public void FinishLevel(int id)
    {
        if (id + 1 < levels.Count)
        {
            CreateLevel(id + 1);
        }
        else
        {
            //GameEnd
        }
    }
}