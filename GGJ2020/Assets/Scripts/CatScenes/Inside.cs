using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inside : CatScene
{
    public GameObject camera1;
    public GameObject camera2;


    public Transform player;
    public Transform target;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator WaitForNextLevel()
    {
        Vector3 pos = player.position;
        camera1.SetActive(false);
        camera2.SetActive(true);
        float time = 5f;
        float cur = 0f;
        yield return null;
        player.gameObject.SetActive(true);
        player.GetComponent<Animator>().SetFloat("Speed", 5f);
        while (true)
        {
            cur += Time.deltaTime;

            player.transform.position = Vector3.Lerp(pos, target.position, cur / time);

            if (cur > time)
            {
                break;
            }

            yield return null;
        }

        yield return null;
        player.gameObject.SetActive(false);
        camera1.SetActive(true);
        camera2.SetActive(false);
        StartNextLevel();
    }
}