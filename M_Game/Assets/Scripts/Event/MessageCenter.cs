using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MsgType
{
    /// <summary>
    /// 游戏开始
    /// </summary>
    GameStart,
    RoleMove,
}

public class MessageEvent
{

    /// <summary>
    /// 用可变参数实现多参数的传递
    /// </summary>
    /// <param name="message"></param>
    public delegate void MessageEventParams(params object[] message);

    /// <summary>
    /// 多参数
    /// </summary>
    public MessageEventParams mep;


    public MessageEvent(MessageEventParams mp)
    {
        mep = mp;
    }
}

public class MessageCenter  {

    public static MessageCenter GlobalEvent
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new MessageCenter();
            return m_Instance;
        }
    }
    private static MessageCenter m_Instance;


    public Dictionary<int, List<MessageEvent>> MsgEventDic
    {
        get; set;
    }

    public MessageCenter()
    {
        MsgEventDic = new Dictionary<int, List<MessageEvent>>();
    }

    public void AddListener(int messageKey, MessageEvent.MessageEventParams messageEvent)
    {
        MessageEvent me = new MessageEvent(messageEvent);
        AddMsg(messageKey, me);
    }

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="messageKey"></param>
    /// <param name="me"></param>
    /// <param name="type">1为mep，2为mes</param>
    void AddMsg(int messageKey, MessageEvent me)
    {
        List<MessageEvent> msgEventL;
        if (!MsgEventDic.TryGetValue(messageKey, out msgEventL))
        {
            msgEventL = new List<MessageEvent>();
            MsgEventDic.Add(messageKey, msgEventL);
        }

        if (!TryGetSameMessEvent(msgEventL, me.mep))
        {
            msgEventL.Add(me);
        }
    }

    /// <summary>
    /// 检查是否有相同的绑定对象，有的话就忽略
    /// </summary>
    /// <param name="msgEventList"></param>
    /// <param name="mep"></param>
    /// <returns></returns>
    bool TryGetSameMessEvent(List<MessageEvent> msgEventList, MessageEvent.MessageEventParams mep)
    {
        for (int i = 0; i < msgEventList.Count; i++)
        {
            if (msgEventList[i].mep == mep)
                return true;
        }
        return false;
    }

    public void Init()
    {

    }

    public void RemoveAllListener()
    {
        MsgEventDic.Clear();
    }

    /// <summary>
    /// 删除当前ID的所有的事件event，
    /// </summary>
    /// <param name="messageKey"></param>
    public void RemoveListener(int messageKey)
    {
        List<MessageEvent> msgEventL;
        if (MsgEventDic.TryGetValue(messageKey, out msgEventL))
        {
            MsgEventDic.Remove(messageKey);
        }
    }

    /// <summary>
    /// 删除指定事件
    /// </summary>
    /// <param name="messageKey">事件ID</param>
    /// <param name="mep">需要删除的方法</param>
    public void RemoveListener(int messageKey, MessageEvent.MessageEventParams messageEvent)
    {
        List<MessageEvent> msgEventL;
        if (MsgEventDic.TryGetValue(messageKey, out msgEventL))
        {
            for (int i = msgEventL.Count - 1; i >= 0; i--)
            {
                if (msgEventL[i].mep == messageEvent)
                {
                    msgEventL.RemoveAt(i);
                }
            }
            if (msgEventL.Count <= 0)
            {
                MsgEventDic.Remove(messageKey);
            }
        }
    }

    public void SendMessage(int messageKey, params object[] message)
    {

        if (MsgEventDic == null) return;

        List<MessageEvent> msgEventL;
        if (MsgEventDic.TryGetValue(messageKey, out msgEventL))
        {
            for (int i = 0; i < msgEventL.Count; i++)
            {
                try
                {
                    MessageEvent messageEvent = msgEventL[i];
                    if (null != messageEvent)
                    {
                        // 委托函数执行
                        //Debug.LogError("委托函数执行:"+ messageEvent.Target);
                        if (messageEvent.mep != null)
                        {
                            messageEvent.mep(message);
                        }
                        else
                        {
                            Debug.LogError("消息注册错误,target为空,消息ID为：" + messageKey);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("OBjs:" + message.Length);
                    Debug.LogError("事件派发出错请检查：" + messageKey + "E:" + e);
                }

            }
        }
    }
}
