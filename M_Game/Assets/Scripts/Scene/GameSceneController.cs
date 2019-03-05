using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每个场景都要自己选择需要的系统,且运行系统逻辑
/// </summary>
public abstract class GameScene
{
    protected GameSceneController _sceneController;
    public GameScene(GameSceneController controller)
    {
        _sceneController = controller;
    }

    public virtual void Start()
    {
        GameSystemMediator.Instance.Init();
    }

    public virtual void Update()
    {
        GameSystemMediator.Instance.Update();
    }

    public virtual void End()
    {
        GameSystemMediator.Instance.Release();
    }
}

public enum SceneType
{
    /// <summary>
    /// 游戏开始界面
    /// </summary>
    GameStartScene,
    /// <summary>
    /// 战斗场景
    /// </summary>
    BattleScene,
}

public class GameSceneController  {

    private GameScene _currentScene;

    public GameScene CurrentScene
    {
        get
        {
            return _currentScene;
        }
    }

    private Dictionary<SceneType, GameScene> _allScene = new Dictionary<SceneType, GameScene>();

    public GameSceneController()
    {
        //再这里创建场景的实例
        _allScene.Add(SceneType.GameStartScene,new GameStartScene(this));
        _allScene.Add(SceneType.BattleScene, new BattleScene(this));
    }


    public void SetCurrentScene(SceneType type)
    {
        if (_currentScene != null)
            _currentScene.End();

        _currentScene = _allScene[type];
        _currentScene.Start();
    }
}
