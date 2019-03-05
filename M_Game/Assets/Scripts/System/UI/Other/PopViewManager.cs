using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopViewManager  {

    public static PopViewManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new PopViewManager();
            return m_Instance;
        }
    }
    private static PopViewManager m_Instance;


    /// <summary>
    /// 弹出有确定取消的窗口,title默认为“提示”
    /// </summary>
    /// <param name="content">内容</param>
    /// <param name="title">标题</param>
    /// <param name="confirmAction">确定按钮的事件</param>
    /// <param name="cancelAction">取消按钮的事件</param>
    public void ShowPopView(string content,string title=null,Action confirmAction = null,Action cancelAction=null)
    {
        UISystem.Instance.OpenUI(UIType.PopView, (obj) =>
        {
            if (title==null)
            {
                title = "提示";
            }
            obj.transform.Find("Title").GetComponent<Text>().text = title;
            obj.transform.Find("Content").GetComponent<Text>().text=content;
            obj.transform.Find("ConfirmBtn").GetComponent<Button>().onClick.AddListener(()=> 
            {
                if (confirmAction != null)
                    confirmAction();
                else
                    UISystem.Instance.CloseUI(UIType.PopView);
            });
            obj.transform.Find("CancelBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (cancelAction != null)
                    cancelAction();
                else
                    UISystem.Instance.CloseUI(UIType.PopView);
            });
        });
    }
    
    /// <summary>
    /// 弹出只有确定的窗口
    /// </summary>
    /// <param name="content"></param>
    /// <param name="title"></param>
    /// <param name="confirmAction"></param>
    public void ShowOnlyConfirmPopView(string content, string title = null, Action confirmAction = null)
    {
        UISystem.Instance.OpenUI(UIType.OnlyConfirmPopView, (obj) =>
        {
            if (title == null)
            {
                title = "提示";
            }
            obj.transform.Find("Title").GetComponent<Text>().text = title;
            obj.transform.Find("Content").GetComponent<Text>().text = content;
            obj.transform.Find("ConfirmBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                if (confirmAction != null)
                    confirmAction();
                else
                    UISystem.Instance.CloseUI(UIType.OnlyConfirmPopView);
            });
        });
    }
}
