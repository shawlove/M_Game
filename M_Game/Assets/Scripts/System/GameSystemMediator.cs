using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SystemType
{
    /// <summary>
    /// UI系统
    /// </summary>
    UISystem,
}

public interface ISystem
{
    bool IsRun { get; set; }

    GameSystemMediator SystemMediator { get;}

    void Init();
    void Update();
    void Release();
}

/// <summary>
/// 系统之间的中介者
/// </summary>
public class GameSystemMediator
{

    public static GameSystemMediator Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new GameSystemMediator();
            return m_Instance;
        }
    }
    private static GameSystemMediator m_Instance;

    private Dictionary<SystemType, ISystem> _allSystem = new Dictionary<SystemType, ISystem>();

    public void Init()
    {
        if (!_allSystem.ContainsKey(SystemType.UISystem))
        {
            _allSystem.Add(SystemType.UISystem, UISystem.Instance);
        }


        foreach (var system in _allSystem.Values)
        {
            system.Init();
        }
    }


    public void Update()
    {
        foreach (var system in _allSystem.Values)
        {
                system.Update();
        }
    }

    public void Release()
    {
        foreach (var system in _allSystem.Values)
        {
            system.Release();
        }
    }

    public void OpenUI(UIType type)
    {
        if (_allSystem.ContainsKey(SystemType.UISystem))
        {
            (_allSystem[SystemType.UISystem] as UISystem).OpenUI(type);
        }
    }

}
