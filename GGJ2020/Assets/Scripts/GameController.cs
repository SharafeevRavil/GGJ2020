using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public List<LevelConfiguration> levels;
    public GameObject levelPrefab;

    [SerializeField] public List<CatScene> catScenes;

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

    public void FinishLevel(int id, GameObject goToDestroy)
    {
        if (id + 1 < levels.Count)
        {
            StartCoroutine(WaitLevelEnd(id, goToDestroy));
        }
        else
        {
            //GameEnd
        }
    }

    private IEnumerator WaitLevelEnd(int id, GameObject goToDestroy)
    {
        yield return new WaitForSeconds(3f);
        StartCatScene(id + 1);
        Destroy(goToDestroy);
    }

    private void StartCatScene(int nextLevelId)
    {
        catScenes[nextLevelId].StartScene(this, nextLevelId);
        //after this catScene should invoke CreateLevel(id + 1);
    }
}