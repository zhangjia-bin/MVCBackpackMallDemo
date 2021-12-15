using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPanelData : ModelBase
{
    #region 无用的重写
    //出初始化数据
    public override void Onload()
    {

        //无用因位面板显示购买数量的数据没有数据的作业，主要依靠的数据是响应点击商品的数据！！
        base.Onload();
    }

    //无用因位面板显示购买数量的数据没有数据的作业，主要依靠的数据是响应点击商品的数据！！
    public override void OnReals()
    {
        base.OnReals();
    }
    #endregion

    public BuyPanelData()
    {
        modelName = ModelName.BuyPanelData;
    }

    //面板的数据 刚开始一个数据也没得
    #region 字段与属性的使用
    ItemData data;

    public ItemData Data { get => data; set => data = value; }

    #endregion


    #region 为显示购买窗口提供购买数据的一些类对外方法

    //改变BuyPanel所储存的数据形式（主要为了响应点商品的时候，存入的数据形式）


    public void ChangeData(ItemData item)
    {
        if (item.Id == -1) return;

        //面板的数据以及修改啦！！！
        Data = item;
    }

    #endregion
}
