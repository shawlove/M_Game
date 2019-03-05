using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private GameSceneController _sceneController;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start () {
        _sceneController = new GameSceneController();
        _sceneController.SetCurrentScene( SceneType.GameStartScene);
    }
	

	void Update () {
        _sceneController.CurrentScene.Update();
    }
}
