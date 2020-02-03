using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest2 : CatScene
{
    public GameObject camera1;
    public GameObject camera2;

    public CharacterController player;
    public Animator animator;

    public float time = 5f;

    public override void StartScene(GameController gameController, int nextLevelId)
    {
        base.StartScene(gameController, nextLevelId);
        StartCoroutine(Move());
        StartCoroutine(WaitForNextLevel());
    }

    // ReSharper disable once InconsistentNaming
    private Vector3 velocity;

    private IEnumerator Move()
    {
        player.gameObject.SetActive(true);
        yield return null;
        animator.SetFloat("Speed", 5f);
        while (true)
        {
            player.Move(player.transform.forward * 2f * Time.deltaTime);

            velocity.y += -9.81f * Time.deltaTime;
            player.Move(velocity * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator WaitForNextLevel()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        yield return new WaitForSeconds(time);
        camera1.SetActive(true);
        camera2.SetActive(false);
        player.gameObject.SetActive(false);
        StartNextLevel();
    }
}