using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : CatScene
{
    public GameObject camera1;
    public GameObject camera2;

    public float time = 5f;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator WaitForNextLevel()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        yield return new WaitForSeconds(time);
        camera1.SetActive(true);
        camera2.SetActive(false);
        StartNextLevel();
    }
}