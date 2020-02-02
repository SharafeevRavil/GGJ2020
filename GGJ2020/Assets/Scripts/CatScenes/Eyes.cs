using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : CatScene
{
    public GameObject camera1;
    public GameObject camera2;

    public SkinnedMeshRenderer renderer;
    public Material mat1;
    public Material mat2;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator WaitForNextLevel()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        float time = 7f;
        float cur = 0f;
        yield return null;
        while (true)
        {
            cur += Time.deltaTime;
            //renderer.material.Lerp(mat1, mat2, cur / time);
            renderer.material.SetFloat("_Blend", cur / time);

            if (cur > time)
            {
                break;
            }

            yield return null;
        }

        yield return null;
        camera1.SetActive(true);
        camera2.SetActive(false);
        StartNextLevel();
    }
}