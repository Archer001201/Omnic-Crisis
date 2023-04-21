using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    private static EventManager _instance = null;
    public static EventManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new EventManager();
        }
        return _instance;
    }

    private EventPool<GameEventArgs> _eventPool;

    public EventManager()
    {
        _eventPool = new EventPool<GameEventArgs>();
    }

    //订阅（注册）事件
    public void Subscribe(int id, EventHandler<GameEventArgs> handler)
    {
        _eventPool.Subscribe(id, handler);
    }

    //取消订阅
    public void Unsubscribe(int id, EventHandler<GameEventArgs> handler)
    {
        _eventPool.Unsubscribe(id, handler);
    }

    //广播
    public void Fire(object sender, int id, GameEventArgs e)
    {
        _eventPool.Fire(sender, id, e);
    }
}
