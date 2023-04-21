using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventPool<T> where T:GameEventArgs
{
    private Dictionary<int, EventHandler<T>> _dicEventHandlers = new Dictionary<int, EventHandler<T>>();

    //检查是否有事件
    public bool Check(int id, EventHandler<T> handler)
    {
        EventHandler<T> handlers = null;
        _dicEventHandlers.TryGetValue(id, out handlers);
        if (handlers == null)
        {
            return false;
        }
        foreach(EventHandler<T> eventHandler in handlers.GetInvocationList())
        {
            if (eventHandler == handler)
            {
                return true;
            }
        }

        return false;
    }

    //注册
    public void Subscribe(int id, EventHandler<T> handler)
    {
        if (handler == null)
        {
            Debug.LogError("无效事件");
            return;
        }
        if (_dicEventHandlers.TryGetValue(id, out EventHandler<T> handlerList) == false)
        {
            _dicEventHandlers[id] = handler;
        }
        else
        {
            if (Check(id, handler))
            {
                Debug.LogError("重复注册");
            }
            else
            {
                _dicEventHandlers[id] += handler;
            }
        }
    }

    //取消注册
    public void Unsubscribe(int id, EventHandler<T> handler)
    {
        if (handler == null)
        {
            Debug.LogError("无效事件");
        }
        if (_dicEventHandlers.ContainsKey(id))
        {
            _dicEventHandlers[id] -= handler;
        }
    }

    //广播
    public void Fire(object sender, int id, T e)
    {
        EventHandler<T> handler = null;
        _dicEventHandlers.TryGetValue(id, out handler);
        if (handler != null)
        {
            handler(sender, e);
        }
    }
}
