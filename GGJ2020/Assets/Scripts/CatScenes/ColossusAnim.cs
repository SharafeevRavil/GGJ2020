using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColossusAnim : CatScene
{
    public Animator colossusAnimator;
    public int animId;

    public GameObject camera1;
    public GameObject camera2;
    
    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(WaitForNextLevel());
    }

    private IEnumerator WaitForNextLevel()
    {
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
        camera1.SetActive(true);
        camera2.SetActive(false);
        StartNextLevel();
    }
    
    
}
