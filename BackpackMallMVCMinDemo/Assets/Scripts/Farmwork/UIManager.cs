
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShowUIName
{
    Shop,
        Bag
}
public enum DisplayType
{
    Zhengchang,
    guding,
    huchi
}
public class UIManager : Singleton<UIManager>
{
    Dictionary<ShowUIName, UIBase> UIdic = new Dictionary<ShowUIName, UIBase>();
    Stack<UIBase> UIstack = new Stack<UIBase>();

    Transform cas;

    public Transform Cas { get => cas; set => cas = value; }

    public UIManager()
    {
        //获取父级画板
        Cas = GameObject.Find("RootCanvas/BagShop/ShopAndBag").transform;
    }


    //显示UI界面
    public void OpenUI(ShowUIName uIName)
    {
        UIBase tem = LoadUIbase(uIName);

        if (tem != null)
        {
            switch (tem.type)
            {
                case DisplayType.Zhengchang:
                    {
                        noremalShow(uIName);
                    }
                    break;
                case DisplayType.huchi:
                    {
                        hideOtherShow(uIName);
                    }
                    break;
                default: break;
            }
        }
        else
        {
            Debug.LogError("该对象为空："+tem);
        }
       
    }


    //关闭UI界面
    public void ClosePanel(ShowUIName uIName)
    {
        UIBase UIBase;
        UIdic.TryGetValue(uIName, out UIBase);
        if (UIBase != null)
        {
            switch (UIBase.type)
            {
                case DisplayType.Zhengchang:
                    {
                        if (UIdic.TryGetValue(uIName, out UIBase))
                        {
                            UIBase.Hide();
                        }
                    }
                    break;
                case DisplayType.huchi:
                    {
                        foreach (var item in UIdic.Values)
                        {
                            item.Hide();
                        }
                        if (UIdic.TryGetValue(uIName, out UIBase))
                        {
                            UIBase.Show();
                        }
                    }
                    break;

                default: break;
            }
        }
    }

    private void hideOtherShow(ShowUIName uIName)
    {
        UIBase UIBase;
        foreach (var item in UIdic.Values)
        {
            item.Hide();
        }

        if (UIdic.TryGetValue(uIName, out UIBase))
        {
            UIBase.Show();
        }
        else
        {
            Debug.Log("字典没有该UI预制体");
            return;
        }
    }

    private void noremalShow(ShowUIName uIName)
    {
        UIBase UIBase;
        if (UIdic.TryGetValue(uIName, out UIBase))
        {
            UIBase.ReDisplay();
        }
        else
        {
            Debug.LogError("字典没有该预制体UI" + uIName);
        }
    }

    UIBase LoadUIbase(ShowUIName uIName)
    {
        UIBase UIBase;
        UIdic.TryGetValue(uIName, out UIBase);
        if (UIBase == null)
        {
            GameObject go = Resources.Load<GameObject>(uIName.ToString());
            if (go == null)
            {
                Debug.Log("没有该UI预制体");
                return null;
            }
            //实例化预制体
            //并显示在UI上
            GameObject Uigo = GameObject.Instantiate<GameObject>(go, Cas.transform, false);

            UIBase = Uigo.GetComponent<UIBase>();
            if (UIBase != null)
            {
                //添加入缓存过的UI
                UIdic.Add(uIName, UIBase);
                //实例化数据以及获取的组件
                UIBase.Init();
                
            }
        }
        else
        {
            UIBase.Show();
        }
        return UIBase;
    }
}
