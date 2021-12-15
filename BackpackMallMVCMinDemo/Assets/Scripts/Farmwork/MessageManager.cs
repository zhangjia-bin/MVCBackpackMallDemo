using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MessageManager : Singleton<MessageManager>
{
    Dictionary<int, Action<object>> dic = new Dictionary<int, Action<object>>();

    public void OnAddliston(int id, Action<object> action)
    {
        if (dic.ContainsKey(id))
        {
            dic[id] += action;
        }
        else
        {
            dic.Add(id, action);
        }
    }

    public void OnRemove(int id, Action<object> action)
    {
        if (dic.ContainsKey(id))
        {
            dic[id] -= action;
            if (dic[id] == null)
            {
                dic.Remove(id);
            }
        }
    }

    public void OnSend(int id, params object[] arr)
    {
        if (dic.ContainsKey(id))
        {
            dic[id](arr);
        }
    }

}

