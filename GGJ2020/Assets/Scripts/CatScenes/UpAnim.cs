using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAnim : CatScene
{
    public Animator colossusAnimator;
    public int animId = 4;

    public GameObject camera1;
    public GameObject camera2;

    public Transform target1;
    public Transform target2;

    public GameObject playerGO;

    public float time = 6f;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(CameraMove());
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator CameraMove()
    {
        float cur = 0f;
        yield return null;
        while (true)
        {
            cur += Time.deltaTime;
            camera2.transform.position = Vector3.Lerp(target1.position, target2.position, cur / time);
            if (cur > time)
            {
                break;
            }

            yield return null;
        }

        yield return null;
    }

    private IEnumerator WaitForNextLevel()
    {
        playerGO.SetActive(true);
        camera1.SetActive(false);
        camera2.SetActive(true);
        colossusAnimator.SetTrigger(animId.ToString());
        yield return null;
        while (true)
        {
            yield return null;
            var info = colossusAnimator.GetCurrentAnimatorStateInfo(0);
            if (info.normalizedTime > 0.99f)
            {
                break;
            }
        }

        yield return null;
        //some shit after
    }
}