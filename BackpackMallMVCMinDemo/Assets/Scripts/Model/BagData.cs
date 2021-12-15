using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagData : ModelBase
{
    public BagData()
    {

        //调用的数据类型
        modelName = ModelName.BagData;
    }
    public override void Onload()
    {
        base.Onload();
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
    #region 为背包数据对外提供一系列接口的方法！！

    /// <summary>
    /// 添加数据进入商城！！！（商城暂时不用加入数据）
    /// </summary>
    public void AddItems(ItemData data)
    {
        //加入数据（半段数据存不存在！！！！）
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == data.Id)
            {
                //叠加效果
                //检测之前的已满的物品跳过效果！！
                if (items[i].Max >= 16)
                {
                    //检测到达了，去下一个循环
                    continue;//到达了16个下一个

                }
                else
                {
                    items[i].Max += data.Max;
                }

                //专门用来添加叠加商品的逻辑
                if (items[i].Max > 16)
                {
                    int num = items[i].Max / 16;
                    int yushu = items[i].Max % 16;

                    //如果格子没满的话就加入一个新的Items
                    for (int j = 0; j < num-1; j++)
                    {
                        //到了16下一个
                        items.Add(new ItemData(data.Id, data.Price, 16));
                    }

                    if (yushu != 0)
                    {
                        items.Add(new ItemData(data.Id, data.Price, yushu));
                    }

                    //原数据恢复为16；
                    items[i].Max = 16;
                    MessageManager.GetT.OnSend(1002);
                    return;

                }
                else
                {
                    MessageManager.GetT.OnSend(1002);
                    return;
                }

               
            }
        }

        //没有的情况下，进行数据添加
        int shu = data.Max / 16;
        int yu = data.Max % 16;
        for (int i = 0; i < shu; i++)
        {
            items.Add(new ItemData(data.Id, data.Price, 16));
        }

        //余数不为0的情况下！！加
        if (yu != 0)
        {
            items.Add(new ItemData(data.Id, data.Price, yu));
        }
        //没有的话加入背包数据
        MessageManager.GetT.OnSend(1002);
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
