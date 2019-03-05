using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task  {

    public long taskID;//任务ID
    public string taskName;//任务名字
    public string caption;//任务描述   

    public Dictionary<MsgType, int> Condition = new Dictionary<MsgType, int>();
    // public List<TaskReward> taskRewards = new List<TaskReward>();


    #region 事件对应任务的检测方法
    private void MoveCheck()
    {

    }
    #endregion

}
