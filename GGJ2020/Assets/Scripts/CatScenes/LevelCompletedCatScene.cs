using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedCatScene : CatScene
{
    public float seconds = 3f;
    public GameObject levelCompletedObject;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator WaitForNextLevel()
    {
        levelCompletedObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        levelCompletedObject.SetActive(false);
        StartNextLevel();
    }
}