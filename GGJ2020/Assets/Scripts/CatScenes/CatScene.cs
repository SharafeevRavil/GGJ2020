using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScene : MonoBehaviour
{
    private int _nextLevelId;
    private GameController _gameController;

    public virtual void StartScene(GameController gameController, int nextLevelId)
    {
        _gameController = gameController;
        _nextLevelId = nextLevelId;
    }

    protected void StartNextLevel()
    {
        _gameController.CreateLevel(_nextLevelId);
    }
}