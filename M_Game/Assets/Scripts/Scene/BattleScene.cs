using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleScene : GameScene
{
    public BattleScene(GameSceneController controller) : base(controller)
    {

    }

    public override void Start()
    {
        base.Start();
        SceneManager.LoadScene("BattleScene");

        PopViewManager.Instance.ShowOnlyConfirmPopView("欢迎进入游戏");
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
