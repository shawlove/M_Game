using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏开始场景，包括选人界面 
/// </summary>
public class GameStartScene : GameScene{
    public GameStartScene(GameSceneController controller) : base(controller)
    {

    }

    public override void Start()
    {
        base.Start();
        
        SceneManager.LoadScene("GameStart");

        GameSystemMediator.Instance.OpenUI(UIType.GameStartUI);

        MessageCenter.GlobalEvent.AddListener((int)MsgType.GameStart, (objs) => { _sceneController.SetCurrentScene(SceneType.BattleScene); });
    }

    public override void Update()
    {
        base.Update();
    }

    public override void End()
    {
        base.End();
    }
}
