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
        StartCatScene(0);
    }

    public void CreateLevel(int id)
    {
        controls.SetActive(true);
        GameObject go = Instantiate(levelPrefab);
        BlockLevel level = go.GetComponent<BlockLevel>();

        level.InitLevel(this, levels[id], id);
    }

    public GameObject controls;

    public void FinishLevel(int id, GameObject goToDestroy)
    {
        if (id + 1 < levels.Count)
        {
            StartCoroutine(WaitLevelEnd(id, goToDestroy));
        }
        else
        {
            //GameEnd
            StartCatScene(7);
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
        controls.SetActive(false);
        catScenes[nextLevelId].StartScene(this, nextLevelId);
        //after this catScene should invoke CreateLevel(id + 1);
    }
}