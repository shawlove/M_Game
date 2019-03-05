using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : ISystem
{
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

    public TaskSystem(GameSystemMediator mediator)
    {
        _systemMediator = mediator;
    }

    private Dictionary<long, Task> _allTask = new Dictionary<long, Task>();

    private Dictionary<long, Task> _acceptTask = new Dictionary<long, Task>();

    private Dictionary<long, Task> _completeTask = new Dictionary<long, Task>();

    public void Init()
    {
        
    }

    public void Release()
    {
        
    }

    public void Update()
    {
        
    }


    public void ParseTask()
    {

    }

    public void AcceptTask()
    {

    }

    public void CancelTask()
    {

    }

}
