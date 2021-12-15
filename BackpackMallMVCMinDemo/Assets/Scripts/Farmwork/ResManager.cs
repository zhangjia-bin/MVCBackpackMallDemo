using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager : Singleton<ResManager>
{
    Dictionary<string, Object> resdic = new Dictionary<string, Object>();

    public T MyLoad<T>(string path) where T : Object
    {
        Object obj;
        if (resdic.TryGetValue(path, out obj))
        {

        }
        else
        {
            obj = Resources.Load<T>(path);
            resdic.Add(path, obj);
        }
        return obj as T;
    }

}