using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 名字和UI预制体保持一致
/// </summary>
public enum UIType
{
    GameStartUI,
    PopView,
    OnlyConfirmPopView,
}


/// <summary>
/// 控制打开关闭UI，每个ui模块一个UIModel（提供对外接口），一个UIView挂载到预制体上
/// </summary>
public class UISystem : MonoBehaviour,ISystem
{
    public static UISystem Instance { get; private set; }


    private const string UI_PREFAB_PATH = "UI/Prefabs/";

    private bool _isRun = true;
    public bool IsRun
    {
        get
        {
            return _isRun;
        }

        set
        {
            _isRun = value;
        }
    }

    private GameSystemMediator _systemMediator;
    public GameSystemMediator SystemMediator
    {
        get
        {
            return _systemMediator;
        }
    }

    private Dictionary<UIType, GameObject> _uiPrefabs;

    public UISystem(GameSystemMediator mediator)
    {
        _systemMediator = mediator;
    }

    
    private void Start()
    {
        Instance = this;
    }

    public void Init()
    {
        _uiPrefabs = new Dictionary<UIType, GameObject>();
    }

    public void Update()
    {
       
    }
    public void Release()
    {

    }


    public void OpenUI(UIType type,Action<GameObject> action=null)
    {
        if (!_uiPrefabs.ContainsKey(type))
        {
            StringBuilder path = new StringBuilder();
            path.Append(UI_PREFAB_PATH);
            path.Append(Enum.GetName(typeof(UIType), type));
            _uiPrefabs.Add(type, Resources.Load(path.ToString()) as GameObject);
        }
        GameObject ui = Instantiate(_uiPrefabs[type]) as GameObject;
        ui.transform.SetParent(transform);
        ui.transform.localPosition = Vector3.zero;
        ui.transform.localScale = Vector3.one;
        ui.SetActive(true);
        if (action != null)
            action(ui);
    }

    public void CloseUI(UIType type,Action<GameObject> action= null)
    {
        if (action != null)
            action(_uiPrefabs[type]);
        if (_uiPrefabs[type].activeSelf)
            _uiPrefabs[type].SetActive(false);
        else
            Debug.Log("你关闭了已经关闭了的UI");
    }

}
