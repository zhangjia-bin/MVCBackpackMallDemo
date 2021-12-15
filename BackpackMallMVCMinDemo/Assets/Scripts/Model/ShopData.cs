using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class ShopData :ModelBase
{
    public ShopData()
    {
        //调用的数据类型
        modelName = ModelName.ShopData;
    }

    public override void Onload()
    {
        base.Onload();
        //解析json文件放入背包
        ParseFile();
    }
    public override void OnReals()
    {
        base.OnReals();
    }

    /// <summary>
    /// 背包里的所有数据信息
    /// </summary>
    /// 
    List<ItemData> items = new List<ItemData>();

    public List<ItemData> Items { get => items; set => items = value; }

    void ParseFile()
    {
        string str = File.ReadAllText("1.json");
        Items = JsonConvert.DeserializeObject<List<ItemData>>(str);
        
    }
    #region 为背包数据对外提供一系列接口的方法！！

    /// <summary>
    /// 添加数据进入商城！！！（商城暂时不用加入数据）
    /// </summary>
    public void AddItems(ItemData data)
    {
        //加入数据
        items.Add(data);
    }


    /// <summary>
    ///删除数据进入商城！！！（商城暂时不用加入数据）
    /// </summary>
    /// 
    public void RemoveItems(ItemData data)
    {
        //删除数据
        items.Remove(data);
    }

    
    /// <summary>
    /// 根据数据id查找商城数据
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ItemData GetItems(int id)
    {
        foreach (var item in items)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        //没有对象返回为空
        return null;

    }

    #endregion
}
