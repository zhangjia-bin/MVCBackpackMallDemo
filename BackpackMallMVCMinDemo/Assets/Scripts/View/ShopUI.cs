using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI :UIBase
{
    public GameObject buyPanel;
    //是否购买
    public Button okbuy;
    //所有的商城格子
    ShopGridBase[] grids;

    public override void Init()
    {
        //获取每个格子挂了脚本的数据
        grids = transform.GetComponentsInChildren<ShopGridBase>();


        //注册确定购买的事件
        okbuy.onClick.AddListener(BuyItems);
        MessageManager.GetT.OnAddliston(1001,UpdatePanel);
        MessageManager.GetT.OnSend(1001);
        base.Init();
    }

    //更新UI面板
    ShopData model;
    private void UpdatePanel(object obj)
    {
        //更新一次商城里面的数据
        model = ModeManager.GetT.GetModel(ModelName.ShopData) as ShopData;
        for (int i = 0; i < grids.Length; i++)
        {
            if (i < model.Items.Count)
            {
                grids[i].UpdatePanel(model.Items[i]);
            }
            else
            {
                //报错提示ing
                Debug.LogError("格子不够！！！");
            }
        }
    }
    BuyPanelData BuyDataModel;
    BagData bagData;
    //购买事件
    private void BuyItems()
    {
        //获取面板的数据
       BuyDataModel= ModeManager.GetT.GetModel(ModelName.BuyPanelData) as BuyPanelData;
        if (BuyDataModel.Data == null) return;
        //显示购买面板
        buyPanel.SetActive(true);
        //显示面板的确认事件

        //购买的数量
        buyPanel.transform.Find("MessShop").GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load<Sprite>("Arts/" + BuyDataModel.Data.Id.ToString());
        //获取确认购买的事件
        buyPanel.transform.Find("OkBuy").GetComponent<Button>().onClick.AddListener(BuyBag);
    }

    private void BuyBag()
    {
        //获取背包数据
        int num = int.Parse(buyPanel.transform.Find("MessShop").GetComponentInChildren<InputField>().text);

        bagData = ModeManager.GetT.GetModel(ModelName.BagData) as BagData;
        //购买的东西及数量
        ItemData item = new ItemData(BuyDataModel.Data.Id, BuyDataModel.Data.Price, num);
        //Debug.Log("添加到背包里面的数据是："+item.Id+"/"+item.Price+"/"+item.Max);
        //添加数据入背包
        bagData.AddItems(item);

        //初始化显示面板
        buyPanel.transform.Find("MessShop").GetComponentInChildren<InputField>().text = 0.ToString();
        buyPanel.gameObject.SetActive(false);
        //购买成功！！！
    }

    public override void Show()
    {
        MessageManager.GetT.OnSend(1001);
        base.Show();
    }
    public override void ReDisplay()
    {
        base.ReDisplay();
    }
    public override void Hide()
    {
        base.Hide();
    }

}
 